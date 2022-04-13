using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.UserAppCategoryWiseappaccess
{
    public interface IUserAppCategoryWiseappaccessRepository
    {

        Response AddUserappCategorywiseappaccess(userapp_Categorywiseappaccess obj_userappCategorywiseappaccess);

        Response GetCategoryAdditionalDataFieldName(string User_category_id,string Customer_id);

        Response Get_category_and_app_access(string Category_id,string Customer_id);



    }
}
