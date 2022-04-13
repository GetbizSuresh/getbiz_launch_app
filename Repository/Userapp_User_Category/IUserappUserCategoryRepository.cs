using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Userapp_User_Category
{
    public interface IUserappUserCategoryRepository
    {

        Response AddUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id,string userapp_category_utc);
        Response UpdateUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id);
        Response GetAllUserappUserCategory(string customer_id);
        Response DeleteUserappUserCategoryById(string Customer_Id, string User_Category_Id, string User_Category_Name);
    }
}
