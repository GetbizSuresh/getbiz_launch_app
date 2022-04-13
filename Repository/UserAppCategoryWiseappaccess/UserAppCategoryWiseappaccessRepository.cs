using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Repository.UserAppCategoryWiseappaccess
{
    public class UserAppCategoryWiseappaccessRepository : IUserAppCategoryWiseappaccessRepository
    {

        public Response AddUserappCategorywiseappaccess(userapp_Categorywiseappaccess obj_userappCategorywiseappaccess)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_getsetdb = new GetSetDatabase();
                var result = Obj_getsetdb.AddUserappCategorywiseappaccess(obj_userappCategorywiseappaccess);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response GetCategoryAdditionalDataFieldName(string User_category_id,string Customer_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                var result = Obj_GetSetDatabase.GetCategoryAdditionalDataFieldName(User_category_id,Customer_id);
                response = result;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
            }
            return response;
        }


        public Response Get_category_and_app_access(string Category_id,string Customer_id)
        {
            Response response = new Response();
            try
            {
                GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                DataSet dset = new DataSet();
                dset = Obj_GetSetDatabase.Get_category_and_app_access(Category_id,Customer_id);
                if (dset.Tables.Count != 0)
                {
                    if (dset.Tables[0].Rows.Count != 0)
                    {

                        List<user_categoryids> objlistparent = new List<user_categoryids>();
                        user_categoryids objparentdata = new user_categoryids();

                        List<user_categoryappids> objlistchild = new List<user_categoryappids>();
                        user_categoryappids objchilddata = new user_categoryappids();


                        for (int i = 0; i < dset.Tables[0].Rows.Count; i++)
                        {
                            objparentdata = new user_categoryids();
                            objparentdata.user_app_category_Id = dset.Tables[0].Rows[i][0].ToString();
                            string categoryid = dset.Tables[0].Rows[i][0].ToString();

                            objlistchild = new List<user_categoryappids>();
                            for (int j = 0; j < dset.Tables[1].Rows.Count; j++)
                            {
                                string check = "0";
                                objchilddata = new user_categoryappids();


                                if (categoryid == (dset.Tables[1].Rows[j][1].ToString()))
                                {
                                    check = "1";
                                    objchilddata.user_app_id = dset.Tables[1].Rows[j][0].ToString();

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

                        userapp_categoryadditional_data objadditional = new userapp_categoryadditional_data();
                        objadditional.additional_user_data_field_name = dset.Tables[2].Rows[0][0].ToString();
                        objadditional.is_face_id_login_mandatory = Convert.ToBoolean(dset.Tables[2].Rows[0][1].ToString());
                        objadditional.is_new_user_upporval_mandatory = Convert.ToBoolean(dset.Tables[2].Rows[0][2].ToString());
                        objadditional.is_business_location_mandatory = Convert.ToBoolean(dset.Tables[2].Rows[0][3].ToString());

                        var testtuple = Tuple.Create(objlistparent, objadditional);


                        response.Data = testtuple;
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "Data not Found...!";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Message ="Oops Something Went Wrong...!";
                    response.Status = false;
                }


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
