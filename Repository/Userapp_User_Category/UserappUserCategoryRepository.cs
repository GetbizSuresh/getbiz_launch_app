using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.Userapp_User_Category
{
    public class UserappUserCategoryRepository : IUserappUserCategoryRepository
    {

        public readonly LaunchAppDB_DbContext _DbContext;
        public UserappUserCategoryRepository(LaunchAppDB_DbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public Response AddUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id,string userapp_category_utc)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.AddUserappUserCategory(obj_userapp_user_category,customer_id, userapp_category_utc);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

      

        public Response UpdateUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateUserappUserCategory(obj_userapp_user_category,customer_id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response DeleteUserappUserCategoryById(string Customer_Id, string User_Category_Id,string User_Category_Name)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.DeleteUserappUserCategoryById(Customer_Id, User_Category_Id, User_Category_Name);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }









        public Response GetAllUserappUserCategory(string customer_id)
        {
            Response response = new Response();
            try
            {
                DataTable ds = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                ds = Obj_getsetdb.GetAllUserappUserCategory(customer_id);

                string JSONresult;
                JSONresult = JsonConvert.SerializeObject(ds);
                response.Data = JSONresult;

                response.Message = "Data Fetch successfully !!";
                response.Status = true;

            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }


        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

      
    }
}
