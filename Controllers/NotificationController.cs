using getbiz_launch_app.Models;
using getbiz_launch_app.Repository.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPush;

namespace getbiz_launch_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private INotificationRepository _notificationrepository;
        public IConfiguration Configuration { get; }

        public NotificationController(INotificationRepository notificationrepository, IConfiguration configuration)
        {
            _notificationrepository = notificationrepository;
            Configuration = configuration;
        }


        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] newSubscriber sub)
        {

            try
            {
                var messages = _notificationrepository.InsertSubscribe(sub);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }


        [HttpPost("broadcast")]
        public IActionResult Broadcast([FromBody] NotificationModel message, [FromServices] VapidDetails vapidDetails)
        {

            try
            {
                List<string> errors = new List<string>();
                var client = new WebPushClient();
                var serializedMessage = JsonConvert.SerializeObject(message);
                List<subscriber> subscribers = new List<subscriber>();
                var receiversString = String.Join(",", message.Receiver_id.ToArray());
                List<int> receivers = new List<int>();
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                    {
                        connection.Open();
                        string sql = $"SELECT * FROM notification_subscribers WHERE user_id IN ({receiversString})";
                        var where = "WHERE user_profile.user_id IN ({receiversString})";
                        string sqq = $"SELECT * FROM user_profile LEFT JOIN notification_subscribers ON notification_subscribers.user_id = user_profile.user_id {where}";
                        MySqlCommand command = new MySqlCommand(sql, connection);
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var user_id = (int)reader["user_id"];
                            if (reader["Endpoint"] == null)
                            {
                                subscribers.Add(new subscriber
                                {
                                    user_id = user_id,
                                    created_at = (DateTime)reader["created_at"],
                                    pushSubscription = new PushSubscription
                                    {
                                        Endpoint = reader["Endpoint"].ToString(),
                                        P256DH = reader["P256DH"].ToString(),
                                        Auth = reader["Auth"].ToString(),
                                    }
                                });
                            }
                            receivers.Add(user_id);
                        }
                        connection.Close();
                    }
                    var uniqueReceivers = new HashSet<int>(receivers);

                    foreach (var user_id in uniqueReceivers)
                    {
                        using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                        {
                            connection.Open();
                            string sql = $@"
                                CREATE TABLE IF NOT EXISTS {user_id}_user_notifications (
                                    id INT AUTO_INCREMENT PRIMARY KEY,
                                    app_id INT NOT NULL,
                                    timestamp DATETIME NOT NULL,
                                    notification_message VARCHAR(200) NOT NULL,
                                    sent_by_user_id INT NOT NULL,
                                    notification_status TINYINT NOT NULL DEFAULT 0,
                                    reply_messages_to_user_notification JSON NOT NULL
                                )  ENGINE=INNODB;
                            ";
                            MySqlCommand command = new MySqlCommand(sql, connection);
                            command.ExecuteNonQuery();
                            connection.Close();
                        }
                        try
                        {
                            using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                            {
                                connection.Open();
                                string sql = $@"
                                 INSERT INTO {user_id}_user_notifications (
                                     app_id,
                                     timestamp,
                                     notification_message,
                                     sent_by_user_id,
                                     notification_status,
                                     reply_messages_to_user_notification
                                 )
                                 VALUES (
                                     @app_id,
                                     @timestamp,
                                     @notification_message,
                                     @sent_by_user_id,
                                     @notification_status,
                                     @reply_messages_to_user_notification
                                 )
                             ";
                                MySqlCommand command = new MySqlCommand(sql, connection);
                                command.Parameters.AddWithValue("@app_id", message.App_id);
                                command.Parameters.AddWithValue("@timestamp", DateTime.Now);
                                command.Parameters.AddWithValue("@notification_message", message.Message);
                                command.Parameters.AddWithValue("@sent_by_user_id", message.Sender_id);
                                command.Parameters.AddWithValue("@notification_status", 0);
                                command.Parameters.AddWithValue("@reply_messages_to_user_notification", message.Reply);

                                command.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            errors.Add(ex.Message);
                        }
                    }

                    foreach (var pushSubscription in subscribers)
                    {
                        try
                        {
                            client.SendNotification(pushSubscription.pushSubscription, serializedMessage, vapidDetails);
                        }
                        catch (Exception ex)
                        {
                            errors.Add(ex.Message);
                            using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                            {
                                connection.Open();
                                string sql = @"
                            DELETE FROM notification_subscribers WHERE auth = @auth ";
                                MySqlCommand command = new MySqlCommand(sql, connection);
                                command.Parameters.AddWithValue("@auth", pushSubscription.pushSubscription.Auth);
                                command.ExecuteNonQuery();
                                connection.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(ex.Message);
                }
                return Ok(errors);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }


        [HttpPost("{user_id}/read/{term}")]
        public IActionResult ReadNotifications(int user_id, string term)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                {
                    connection.Open();
                    string where = term == "all" ? "notification_status = 0" : $@"id = {term}";
                    string sql = $@"
                        UPDATE {user_id}_user_notifications
                        SET notification_status = @notification_status
                        WHERE {where}
                    ";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@notification_status", "1");
                    command.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Success");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }

        [HttpGet("{user_id}/{app_id}/{page}")]
        public IActionResult GetNotifications(int user_id, int page = 1, int app_id = 0)
        {
            int offset = 10 * (page - 1);
            string app;
            if (app_id == 0)
            {
                app = "";
            }
            else
            {
                app = $" WHERE {user_id}_user_notifications.app_id = {app_id}";
            }
            try
            {
                List<NotificationDisplayModel> notifications = new List<NotificationDisplayModel>();
                using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                {
                    connection.Open();
                    string sql = $@"SELECT * FROM {user_id}_user_notifications JOIN user_profile ON user_profile.user_id = {user_id}_user_notifications.sent_by_user_id {app} ORDER BY {user_id}_user_notifications.timestamp DESC LIMIT 10 OFFSET {offset}";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        notifications.Add(new NotificationDisplayModel
                        {
                            id = reader.GetInt32("id"),
                            sender_name = $@"{reader["first_name"]} {reader["last_name"]}",
                            sender_info = reader["additional_user_data_field_values"].ToString(),
                            message = reader["notification_message"].ToString(),
                            timestamp = (DateTime)reader.GetMySqlDateTime("timestamp"),
                            notification_status = reader.GetInt32("notification_status")
                        });
                    }
                    connection.Close();
                }
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpGet("unread/{user_id}")]
        public IActionResult GetUnreadNotifications(int user_id)
        {
            try
            {
                int notifications = 0;
                using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                {
                    connection.Open();
                    string sql = $@"SELECT COUNT(*) FROM {user_id}_user_notifications WHERE notification_status = 0";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    int reader = int.Parse(command.ExecuteScalar().ToString());
                    notifications = reader;
                    connection.Close();
                }
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        [HttpPost("unsubscribe")]
        public IActionResult Unsubscribe([FromBody] newSubscriber sub)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(Configuration["ConnectionStrings:DefaultConnection"]))
                {
                    connection.Open();
                    string sql = @"
                    DELETE FROM notification_subscribers WHERE auth = @auth ";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@auth", sub.pushSubscription.Auth);
                    command.ExecuteNonQuery();
                    connection.Close();
                    return Ok("Success");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


    }
}
