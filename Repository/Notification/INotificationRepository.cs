using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Notification
{
    public interface INotificationRepository
    {
        Response InsertSubscribe(newSubscriber sub);

    }
}
