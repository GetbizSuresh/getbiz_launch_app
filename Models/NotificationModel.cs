using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPush;

namespace getbiz_launch_app.Models
{
    public class NotificationModel
    {
        public int App_id { get; set; }
        public int Sender_id { get; set; }
        public List<int> Receiver_id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public string Reply { get; set; }
    }

    public class NotificationDataModel
    {

        public int app_id { get; set; }
        public string message { get; set; }
        public int sent_by_user_id { get; set; }
    }
    public class NotificationDisplayModel
    {

        public int id { get; set; }
        public string sender_name { get; set; }
        public string sender_info { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public int notification_status { get; set; }
    }
    public class subscriber
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public DateTime created_at { get; set; }
        public PushSubscription pushSubscription { get; set; }
    }
    public class newSubscriber
    {
        public int user_id { get; set; }
        public PushSubscription pushSubscription { get; set; }
    }

    public class Receiver
    {
        public int user_id { get; set; }
    }






}
