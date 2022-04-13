using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Notification
{
    public class NotificationRepository : INotificationRepository
    {


        public Response InsertSubscribe(newSubscriber sub)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.InsertSubscribe(sub);
                response = result;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }








    }
}
