using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace getbiz_launch_app.Repository.User_Profile
{
    public class UserProfileRepository : IUserProfileRepository
    {
        //public readonly LaunchAppDB_DbContext _DbContext;
        //public UserProfileRepository(LaunchAppDB_DbContext DbContext)
        //{
        //    _DbContext = DbContext;
        //}

        public Response AddUserProfile(user_profile obj_user_profile)
        {
            Response response = new Response();
            try
            {  
                    GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                    var result = Obj_getsetdb.AddUserProfile(obj_user_profile);
                    response = result;      
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response UpdateUserProfile(user_profile obj_user_profile)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateUserProfile(obj_user_profile);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response GetUserProfile(string Customet_Id, Int64 User_id)
        {
            Response response = new Response();
            try
            {
                DataSet ds = new DataSet();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                ds = Obj_getsetdb.GetUserProfile(Customet_Id, User_id);



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

        public Response GetUserRegistrationApprovalStatusFieldBased(string customer_id, Int64 user_registration_approval_status)
        {
            Response response = new Response();
            try
            {
                DataTable ds = new DataTable();

                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                ds = Obj_getsetdb.GetUserRegistrationApprovalStatusFieldBased(customer_id, user_registration_approval_status);



                //List<vm_user_login_data> vm_user_login_data_Details = new List<vm_user_login_data>();
                //vm_user_login_data_Details = ConvertDataTable<vm_user_login_data>(ds);
                //response.Data = (vm_user_login_data_Details).ToList();


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

        public Response UpdateUserRegistrationApprovalStatus(string Customet_Id, Int64 User_Registration_Approval_Status, Int64 User_Id, Int64 From_Id)
        {

            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateUserRegistrationApprovalStatus(Customet_Id, User_Registration_Approval_Status, User_Id, From_Id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response UpdateUserProfileMobileNumber(string Customet_Id, string Login_Mobile_No, Int64 User_Id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.UpdateUserProfileMobileNumber( Customet_Id,  Login_Mobile_No,  User_Id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response GetVerifyuser(UserLogin obj_userlogin)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.GetVerifyuser(obj_userlogin);
                response = result;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response Getlaunchrecent_apps(string customer_id, string userid)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.Getlaunchrecent_apps(customer_id, userid);
                response = result;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }




        public Response Getlaunchfavourite_apps(string customer_id, string userid)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.Getlaunchfavourite_apps(customer_id,userid);
                response = result;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response Getlaunchscreen_apps(string customer_id, string userid)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                DataSet dset = new DataSet();
                dset = Obj_GetSetDatabase.Getlaunchscreen_apps(customer_id, userid);

                List<launch_categoryname> objlistparent = new List<launch_categoryname>();
                launch_categoryname objparentdata = new launch_categoryname();

                List<launch_category_json> objlistchild = new List<launch_category_json>();
                launch_category_json objchilddata = new launch_category_json();


                for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                {
                    objparentdata = new launch_categoryname();
                    objparentdata.user_app_category_name = dset.Tables[0].Rows[i][0].ToString();
                    string categoryid = dset.Tables[0].Rows[i][1].ToString();
                    //DataTable Store = dset.Tables[1];

                    //var dataRow = Store.AsEnumerable().Where(x => x.Field<string>("getster_app_category_id") == categoryid).ToList();

                    //if (dataRow.Count > 0)
                    //{
                    objlistchild = new List<launch_category_json>();
                    for (int j = 0; j < dset.Tables[1].Rows.Count; j++)
                    {
                        string check = "0";
                        objchilddata = new launch_category_json();


                        if (categoryid == (dset.Tables[1].Rows[j][0].ToString()))
                        {
                            check = "1";
                            objchilddata.app_id = dset.Tables[1].Rows[j][1].ToString();
                            objchilddata.is_custom_app = Convert.ToBoolean(dset.Tables[1].Rows[j][2].ToString());
                            objchilddata.app_icon_image_path = dset.Tables[1].Rows[j][1].ToString() + "//" + dset.Tables[1].Rows[j][3].ToString();
                            objchilddata.app_icon_name = dset.Tables[1].Rows[j][4].ToString();
                            objchilddata.app_location_within_the_category_id = dset.Tables[1].Rows[j][5].ToString();
                        }


                        if (check == "1")
                        {
                            check = "0";
                            objlistchild.Add(objchilddata);
                        }


                    }
                    //  }


                    objparentdata.data = objlistchild;

                    objlistparent.Add(objparentdata);

                }





                response.Data = objlistparent;
                response.Status = true;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }



        public Response AddFavouriteAppScreens(FavouriteAppScreens objfavourite)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddFavouriteAppScreens(objfavourite);
                response = result;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response AddRecentAppScreens(RecentAppScreens objrecent)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.AddRecentAppScreens(objrecent);
                response = result;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response GetLaunchScreenApps(string customer_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.GetLaunchScreenApps(customer_id);
                response = result;


            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Response GetBusinessCategoriesApps(string customer_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.GetBusinessCategoriesApps(customer_id);
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
