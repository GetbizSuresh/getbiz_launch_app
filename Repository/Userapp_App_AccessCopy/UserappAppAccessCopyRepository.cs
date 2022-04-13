using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Userapp_App_AccessCopy
{
    public class UserappAppAccessCopyRepository : IUserappAppAccessCopyRepository
    {

        public readonly LaunchAppDB_DbContext _DbContext;
        public UserappAppAccessCopyRepository(LaunchAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }


        //public Response AddUserappAppAccessCopy(userapp_app_access_copy obj_userapp_app_access_copy)
        //{
        //    Response response = new Response();
        //    try
        //    {
        //        GetSetDatabase Obj_getsetdb = new GetSetDatabase();
        //        var result = Obj_getsetdb.AddUserappAppAccessCopy(obj_userapp_app_access_copy);
        //        response = result;
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Status = false;
        //        response.Message = ex.Message;
        //    }
        //    return response;
        //}
    }
}
