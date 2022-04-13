using getbiz_launch_app.Helpers;
using getbiz_launch_app.Models;
using MySqlConnector;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Getbiz_DbContext
{
    public class GetSetDatabase
    {
       string connection = "Server=185.252.235.20;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=launchappdb; Allow User Variables=true";

       // string connection = "Server=localhost;User ID=root;Password=GetBizMysqlDatabasePwd2021@;Database=launchappdb; Allow User Variables=true";

        public Response UpdateIncompleteRegister(incomplete_customer_registration_data_Step3 obj_incomplete_customer_registration_data_Step3)
        {
            Response response = new Response();
            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[19];
                {

                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_id", MySqlDbType.Int64);
                    param[0].Value = obj_incomplete_customer_registration_data_Step3.id;

                    param[1] = new MySqlParameter("p_reg_business_name", MySqlDbType.VarChar);
                    param[1].Value = obj_incomplete_customer_registration_data_Step3.registered_business_name;

                    param[2] = new MySqlParameter("p_add_line_1", MySqlDbType.VarChar);
                    param[2].Value = obj_incomplete_customer_registration_data_Step3.address_line_1;

                    param[3] = new MySqlParameter("p_add_line_2", MySqlDbType.VarChar);
                    param[3].Value = obj_incomplete_customer_registration_data_Step3.address_line_2;

                    param[4] = new MySqlParameter("p_city_town_vill", MySqlDbType.VarChar);
                    param[4].Value = obj_incomplete_customer_registration_data_Step3.city_town_village;

                    param[5] = new MySqlParameter("p_district_county", MySqlDbType.VarChar);
                    param[5].Value = obj_incomplete_customer_registration_data_Step3.district_county;



                    param[6] = new MySqlParameter("p_state_province", MySqlDbType.VarChar);
                    param[6].Value = obj_incomplete_customer_registration_data_Step3.state_province;

                    param[7] = new MySqlParameter("p_pin_code", MySqlDbType.VarChar);
                    param[7].Value = obj_incomplete_customer_registration_data_Step3.pin_code;

                    param[8] = new MySqlParameter("p_country", MySqlDbType.VarChar);
                    param[8].Value = obj_incomplete_customer_registration_data_Step3.country;


             
                    param[9] = new MySqlParameter("p_business_phone_number", MySqlDbType.VarChar);
                    param[9].Value = obj_incomplete_customer_registration_data_Step3.business_phone_number;

                    param[10] = new MySqlParameter("p_business_phone_number_verified", MySqlDbType.Bool);
                    param[10].Value = obj_incomplete_customer_registration_data_Step3.business_phone_number_verified;


                    param[11] = new MySqlParameter("p_key_contact_mobile_number", MySqlDbType.VarChar);
                    param[11].Value = obj_incomplete_customer_registration_data_Step3.key_contact_mobile_number;

                    param[12] = new MySqlParameter("p_key_contact_mobile_number_verified", MySqlDbType.Bool);
                    param[12].Value = obj_incomplete_customer_registration_data_Step3.key_contact_mobile_number_verified;



                    param[13] = new MySqlParameter("p_official_email_id", MySqlDbType.VarChar);
                    param[13].Value = obj_incomplete_customer_registration_data_Step3.official_email_id;

                    param[14] = new MySqlParameter("p_number_of_employees", MySqlDbType.VarChar);
                    param[14].Value = obj_incomplete_customer_registration_data_Step3.number_of_employees;

                    param[15] = new MySqlParameter("p_country_code", MySqlDbType.VarChar);
                    param[15].Value = obj_incomplete_customer_registration_data_Step3.country_code;



                    param[16] = new MySqlParameter("p_map_location_display_name ", MySqlDbType.VarChar);
                    param[16].Value = obj_incomplete_customer_registration_data_Step3.map_location_display_name;

                    param[17] = new MySqlParameter("p_gps_coordinates", MySqlDbType.VarChar);
                    param[17].Value = obj_incomplete_customer_registration_data_Step3.gps_coordinates;

                    param[18] = new MySqlParameter("p_google_place_id ", MySqlDbType.VarChar);
                    param[18].Value = obj_incomplete_customer_registration_data_Step3.google_place_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserAppIncompleteRegister", param);

                }
                if (ds.Tables.Count > 0)
                {
                    DataSet dsetmaxid = new DataSet();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MySqlParameter[] param1 = new MySqlParameter[5];

                        string GetMaxId = ds.Tables[0].Rows[0]["MaxId"].ToString();
                        using MySqlConnection con1 = new MySqlConnection(connection);
                        {
                            param1[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                            param1[0].Value = GetMaxId;

                            param1[1] = new MySqlParameter("p_id", MySqlDbType.Int64);
                            param1[1].Value = obj_incomplete_customer_registration_data_Step3.id;


                            param1[2] = new MySqlParameter("p_country_code", MySqlDbType.VarChar);
                            param1[2].Value = obj_incomplete_customer_registration_data_Step3.country_code;

                            param1[3] = new MySqlParameter("p_number_of_employees", MySqlDbType.Int64);
                            param1[3].Value = obj_incomplete_customer_registration_data_Step3.number_of_employees;

                            param1[4] = new MySqlParameter("p_business_phone_number", MySqlDbType.VarChar);
                            param1[4].Value = obj_incomplete_customer_registration_data_Step3.business_phone_number;

                            dsetmaxid = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_InsertDynamicCustomerDB", param1);
                        }
                        if (Convert.ToString(dsetmaxid.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Inserted Successfull";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(dsetmaxid.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(dsetmaxid.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }

                    }
                }


            }
            catch (Exception ex)
            {
                response.Data = ex.Message;
                response.Message = "Oops Some thing went Wrong..!";
                response.Status = false;
            }
            return response;

        }

        public DataTable GetUser(user_profile obj_user_profile)
        {
            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[1] = new MySqlParameter("p_Customet_Id", MySqlDbType.VarChar);
                    param[1].Value = obj_user_profile.customer_id;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUser", param);
                    return ds;
                }
            }

            catch (Exception ex)
            {

            }
            return ds;
        }

        public DataTable GetUserRegistrationApprovalStatusFieldBased(string customer_id, Int64 user_registration_approval_status)
        {
            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_User_Registration_Approval_Status", MySqlDbType.Int64);
                    param[0].Value = user_registration_approval_status;

                    param[1] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[1].Value = customer_id;

                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetUserRegistrationApprovalStatusFieldBased", param);
                    return ds;
                }
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return ds;
        }

        public Response AddUserProfile(user_profile obj_user_profile)
        {
            Response response = new Response();
            DataSet dsetup = new DataSet();
          string user_category_id = JsonConvert.SerializeObject(obj_user_profile.user_category_id);
            string assignpwd = SecureHelper.ECode(obj_user_profile.user_password);

            DataSet dsetcheck = new DataSet();

            try
            {
                MySqlParameter[] checkparam = new MySqlParameter[2];

                using MySqlConnection checkusercon = new MySqlConnection(connection);
                {
                    checkparam[0] = new MySqlParameter("p_login_mobile_no", MySqlDbType.VarChar); //VarChar
                    checkparam[0].Value = obj_user_profile.login_mobile_no;
                    checkparam[1] = new MySqlParameter("p_subdomianname", MySqlDbType.VarChar);
                    checkparam[1].Value = obj_user_profile.Subdomianname;
                    dsetcheck = SqlHelpher.ExecuteDataset(checkusercon, CommandType.StoredProcedure, "SP_CheckVaildUser", checkparam);
                }
                if(dsetcheck.Tables.Count != 0) {
                string getcount= dsetcheck.Tables[0].Rows[0]["checkcount"].ToString();
                string customer_id = dsetcheck.Tables[0].Rows[0]["customer_id"].ToString();
                if (getcount == "0")
                {
                    MySqlParameter[] param = new MySqlParameter[23];

                    using MySqlConnection con = new MySqlConnection(connection);
                    {
                        param[0] = new MySqlParameter("p_login_mobile_no", MySqlDbType.VarChar); //VarChar
                        param[0].Value = obj_user_profile.login_mobile_no;

                        param[1] = new MySqlParameter("p_first_name", MySqlDbType.VarChar);
                        param[1].Value = obj_user_profile.first_name;

                        param[2] = new MySqlParameter("p_last_name", MySqlDbType.VarChar);
                        param[2].Value = obj_user_profile.last_name;

                        param[3] = new MySqlParameter("p_additional_user_data_field_values", MySqlDbType.VarChar);
                        param[3].Value = obj_user_profile.additional_user_data_field_values;

                        param[4] = new MySqlParameter("p_about_user", MySqlDbType.VarChar);
                        param[4].Value = obj_user_profile.about_user;

                        param[5] = new MySqlParameter("p_biz_card_company_details", MySqlDbType.VarChar);
                        param[5].Value = obj_user_profile.biz_card_company_details;

                        param[6] = new MySqlParameter("p_biz_card_mobile_no", MySqlDbType.VarChar);
                        param[6].Value = obj_user_profile.biz_card_mobile_no;

                        param[7] = new MySqlParameter("p_biz_card_phone_no", MySqlDbType.VarChar);
                        param[7].Value = obj_user_profile.biz_card_phone_no;

                        param[8] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                        param[8].Value = "Insert";

                        param[9] = new MySqlParameter("p_biz_card_website", MySqlDbType.VarChar);
                        param[9].Value = obj_user_profile.biz_card_website;

                        param[10] = new MySqlParameter("p_biz_card_email_id", MySqlDbType.VarChar);
                        param[10].Value = obj_user_profile.biz_card_email_id;


                        param[11] = new MySqlParameter("p_biz_card_address", MySqlDbType.VarChar);
                        param[11].Value = obj_user_profile.biz_card_address;

                        param[12] = new MySqlParameter("p_biz_card_address_gps", MySqlDbType.VarChar);
                        param[12].Value = obj_user_profile.biz_card_address_gps;

                        param[13] = new MySqlParameter("p_face_recognition_approval_data", MySqlDbType.VarChar);
                        param[13].Value = obj_user_profile.face_recognition_approval_data;

                        param[14] = new MySqlParameter("p_user_registration_approval_date", MySqlDbType.VarChar);
                        param[14].Value = obj_user_profile.user_registration_approval_date;

                        param[15] = new MySqlParameter("p_user_profile_update_date", MySqlDbType.VarChar);
                        param[15].Value = obj_user_profile.user_profile_update_date;

                        param[16] = new MySqlParameter("p_user_registration_timestamp", MySqlDbType.VarChar);
                        param[16].Value = obj_user_profile.user_registration_timestamp;

                        param[17] = new MySqlParameter("p_user_password", MySqlDbType.VarChar);
                        param[17].Value = assignpwd;

                        param[18] = new MySqlParameter("p_user_registration_approval_status", MySqlDbType.Int64);
                        param[18].Value = obj_user_profile.user_registration_approval_status;

                        param[19] = new MySqlParameter("p_face_recognition_filenames", MySqlDbType.VarChar);
                        param[19].Value = obj_user_profile.face_recognition_filenames;

                        param[20] = new MySqlParameter("p_last_login_timestamp", MySqlDbType.VarChar);
                        param[20].Value = obj_user_profile.last_login_timestamp;

                        param[21] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                        param[21].Value = customer_id;

                        param[22] = new MySqlParameter("P_user_id", MySqlDbType.Int64); //VarChar
                        param[22].Value = obj_user_profile.user_id;

                        dsetup = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserProfile", param);
                    }

                    if (dsetup.Tables.Count > 0)
                    {
                        if (dsetup.Tables[0].Rows.Count > 0)
                        {
                            MySqlParameter[] param1 = new MySqlParameter[12];

                            string GetMaxId = dsetup.Tables[0].Rows[0]["MaxId"].ToString();
                                string user_category_update_timestamp = dsetup.Tables[1].Rows[0]["user_category_update_timestamp"].ToString();
                                string user_app_update_time_stamp = dsetup.Tables[2].Rows[0]["user_app_update_time_stamp"].ToString();
                                string custom_app_update_utc_timestamp = dsetup.Tables[3].Rows[0]["custom_app_update_utc_timestamp"].ToString();

                                using MySqlConnection con1 = new MySqlConnection(connection);
                            {
                                param1[0] = new MySqlParameter("p_Maxid", MySqlDbType.Int64);
                                param1[0].Value = GetMaxId;

                                param1[1] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                                param1[1].Value = customer_id;

                                param1[2] = new MySqlParameter("p_user_category_id", MySqlDbType.JSON);
                                param1[2].Value = user_category_id;

                                param1[3] = new MySqlParameter("p_biz_card_phone_no", MySqlDbType.VarChar);
                                param1[3].Value = obj_user_profile.biz_card_phone_no;

                                param1[4] = new MySqlParameter("p_login_mobile_no", MySqlDbType.VarChar); //VarChar
                                param1[4].Value = obj_user_profile.login_mobile_no;

                                param1[5] = new MySqlParameter("p_user_password", MySqlDbType.VarChar);
                                param1[5].Value = assignpwd;

                                param1[6] = new MySqlParameter("p_user_registration_approval_status", MySqlDbType.Int64);
                                param1[6].Value = obj_user_profile.user_registration_approval_status;

                                param1[7] = new MySqlParameter("p_face_recognition_filenames", MySqlDbType.VarChar);
                                param1[7].Value = obj_user_profile.face_recognition_filenames;

                                param1[8] = new MySqlParameter("p_last_login_timestamp", MySqlDbType.VarChar);
                                param1[8].Value = obj_user_profile.last_login_timestamp;


                                    param1[9] = new MySqlParameter("p_user_category_update_timestamp", MySqlDbType.VarChar);
                                    param1[9].Value = user_category_update_timestamp.Trim();

                                    param1[10] = new MySqlParameter("p_user_app_update_time_stamp", MySqlDbType.VarChar);
                                    param1[10].Value = user_app_update_time_stamp.Trim();

                                    param1[11] = new MySqlParameter("p_custom_app_update_utc_timestamp", MySqlDbType.VarChar);
                                    param1[11].Value = custom_app_update_utc_timestamp.Trim();

                                    dsetup = SqlHelpher.ExecuteDataset(con1, CommandType.StoredProcedure, "SP_InsertUserProfile1", param1);
                            }
                        }


                        if (dsetup.Tables[0].Rows.Count > 0)
                        {

                            if (Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]) == "200")
                            {

                                response.Data = "";

                                response.Message = "Add UserProfile Successfull !! ";
                                response.Status = true;
                            }
                            else
                            {
                                response.Message = Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]);
                                response.Status = Convert.ToInt32(dsetup.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                            }
                        }
                    }

                }
                else if(getcount !="0")
                {
                    response.Message = "Duplicate found ...!";
                    response.Status = false;
                }
                else
                {
                    response.Message = "Oops Something went Wrong ...!";
                    response.Status = false;
                }
                }
                else
                {
                    response.Message = "Check Subdomainname";
                    response.Status = false;
                }
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response UpdateUserProfile(user_profile obj_user_profile)
        {
            Response response = new Response();
            DataSet dsetup = new DataSet();

            MySqlParameter[] param = new MySqlParameter[23];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_login_mobile_no", MySqlDbType.VarChar); //VarChar
                    param[0].Value = obj_user_profile.login_mobile_no;

                    param[1] = new MySqlParameter("p_first_name", MySqlDbType.VarChar);
                    param[1].Value = obj_user_profile.first_name;

                    param[2] = new MySqlParameter("p_last_name", MySqlDbType.VarChar);
                    param[2].Value = obj_user_profile.last_name;

                    param[3] = new MySqlParameter("p_additional_user_data_field_values", MySqlDbType.VarChar);
                    param[3].Value = obj_user_profile.additional_user_data_field_values;

                    param[4] = new MySqlParameter("p_about_user", MySqlDbType.VarChar);
                    param[4].Value = obj_user_profile.about_user;

                    param[5] = new MySqlParameter("p_biz_card_company_details", MySqlDbType.VarChar);
                    param[5].Value = obj_user_profile.biz_card_company_details;

                    param[6] = new MySqlParameter("p_biz_card_mobile_no", MySqlDbType.VarChar);
                    param[6].Value = obj_user_profile.biz_card_mobile_no;

                    param[7] = new MySqlParameter("p_biz_card_phone_no", MySqlDbType.VarChar);
                    param[7].Value = obj_user_profile.biz_card_phone_no;

                    param[8] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[8].Value = "Update";

                    param[9] = new MySqlParameter("p_biz_card_website", MySqlDbType.VarChar);
                    param[9].Value = obj_user_profile.biz_card_website;

                    param[10] = new MySqlParameter("p_biz_card_email_id", MySqlDbType.VarChar);
                    param[10].Value = obj_user_profile.biz_card_email_id;


                    param[11] = new MySqlParameter("p_biz_card_address", MySqlDbType.VarChar);
                    param[11].Value = obj_user_profile.biz_card_address;

                    param[12] = new MySqlParameter("p_biz_card_address_gps", MySqlDbType.VarChar);
                    param[12].Value = obj_user_profile.biz_card_address_gps;

                    param[13] = new MySqlParameter("p_face_recognition_approval_data", MySqlDbType.VarChar);
                    param[13].Value = obj_user_profile.face_recognition_approval_data;

                    param[14] = new MySqlParameter("p_user_registration_approval_date", MySqlDbType.VarChar);
                    param[14].Value = obj_user_profile.user_registration_approval_date;

                    param[15] = new MySqlParameter("p_user_profile_update_date", MySqlDbType.VarChar);
                    param[15].Value = obj_user_profile.user_profile_update_date;

                    param[16] = new MySqlParameter("p_user_registration_timestamp", MySqlDbType.VarChar);
                    param[16].Value = obj_user_profile.user_registration_timestamp;

                    param[17] = new MySqlParameter("p_user_password", MySqlDbType.VarChar);
                    param[17].Value = obj_user_profile.user_password;

                    param[18] = new MySqlParameter("p_user_registration_approval_status", MySqlDbType.Int64);
                    param[18].Value = obj_user_profile.user_registration_approval_status;

                    param[19] = new MySqlParameter("p_face_recognition_filenames", MySqlDbType.VarChar);
                    param[19].Value = obj_user_profile.face_recognition_filenames;

                    param[20] = new MySqlParameter("p_last_login_timestamp", MySqlDbType.VarChar);
                    param[20].Value = obj_user_profile.last_login_timestamp;

                    param[21] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[21].Value = obj_user_profile.customer_id;

                    param[22] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[22].Value = obj_user_profile.user_id;

                    dsetup = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserProfile", param);

                }
                if (dsetup.Tables.Count > 0)
                {
                    if (dsetup.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Update UserProfile Successfull !! ";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(dsetup.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }





            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response UpdateUserProfileMobileNumber(string Customet_Id, string Login_Mobile_No, Int64 User_Id)
        {
            Response response = new Response();
            DataSet dsetup = new DataSet();

            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_login_mobile_no", MySqlDbType.VarChar); //VarChar
                    param[0].Value = Login_Mobile_No;

                    param[1] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[1].Value = Customet_Id;

                    param[2] = new MySqlParameter("p_user_id", MySqlDbType.Int64);
                    param[2].Value = User_Id;

                    dsetup = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserProfileMobileNumber", param);

                }
                if (dsetup.Tables.Count > 0)
                {
                    if (dsetup.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Update Mobile Number Successfull !! ";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(dsetup.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }





            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public DataSet GetUserProfile(string Customet_Id, Int64 User_Id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();

            MySqlParameter[] param = new MySqlParameter[2];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_User_Id", MySqlDbType.Int64);
                    param[0].Value = User_Id;

                    param[1] = new MySqlParameter("p_Customet_Id", MySqlDbType.VarChar);
                    param[1].Value = Customet_Id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetGetUserProfile", param);
                    return ds;
                }
            }

            catch (Exception ex)
            {

            }
            return ds;
        }

        public Response UpdateUserRegistrationApprovalStatus(string Customet_Id, Int64 User_Registration_Approval_Status, Int64 User_Id, Int64 From_Id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();


            MySqlParameter[] param = new MySqlParameter[4];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_User_Registration_Approval_Status", MySqlDbType.Int64);
                    param[0].Value = User_Registration_Approval_Status;

                    param[1] = new MySqlParameter("p_Customet_Id", MySqlDbType.VarChar);
                    param[1].Value = Customet_Id;

                    param[2] = new MySqlParameter("p_User_Id", MySqlDbType.Int64);
                    param[2].Value = User_Id;

                    param[3] = new MySqlParameter("p_From_Id", MySqlDbType.Int64);
                    param[3].Value = From_Id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserRegistrationApprovalStatus", param);

                }

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Update UserRegistrationApprovalStatus Successfull !! ";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }


            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public Response AddUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id,string userapp_category_utc)
        {
            Response response = new Response();
            DataSet dsetup = new DataSet();


            MySqlParameter[] param = new MySqlParameter[6];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_category_id", MySqlDbType.VarChar); //VarChar
                    param[0].Value = obj_userapp_user_category.user_category_id;

                    param[1] = new MySqlParameter("p_user_category_path", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_user_category.user_category_path;

                    param[2] = new MySqlParameter("p_user_category_name", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_user_category.user_category_name;

                    param[3] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[3].Value = customer_id;

                    param[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[4].Value = "Insert";
                    param[5] = new MySqlParameter("p_userapp_category_utc", MySqlDbType.VarChar);
                    param[5].Value = userapp_category_utc.Trim();

                    dsetup = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserappUserCategory", param);

                }
                if (dsetup.Tables.Count > 0)
                {
                    //if(Convert.ToString(dsetup.Tables[1].Rows[0]["checkcustomapp"]) != "0")
                    //{

                        if (dsetup.Tables[0].Rows.Count > 0)
                        {
         
                            DataSet checktimestampds = new DataSet();
                            MySqlParameter[] checktimestampparam = new MySqlParameter[3];
                            string getcount = dsetup.Tables[0].Rows[0]["timestampcount"].ToString();
                            using MySqlConnection conn = new MySqlConnection(connection);
                            {
                                checktimestampparam[0] = new MySqlParameter("p_checkcount", MySqlDbType.VarChar); //VarChar
                                checktimestampparam[0].Value = getcount;
                                checktimestampparam[1] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar); //VarChar
                                checktimestampparam[1].Value = customer_id;
                                checktimestampparam[2] = new MySqlParameter("p_userapp_category_utc", MySqlDbType.VarChar); //VarChar
                                checktimestampparam[2].Value = userapp_category_utc.Trim();
                                checktimestampds = SqlHelpher.ExecuteDataset(conn, CommandType.StoredProcedure, "SP_Checktimestampcategory", checktimestampparam);
                            }
                            if (Convert.ToString(checktimestampds.Tables[0].Rows[0]["Status"]) == "200")
                            {
                                response.Data = "";
                                response.Message = "Add UserappUserCategory Successfull !! ";
                                response.Status = true;
                            }
                            else
                            {
                                response.Message = "Oops Something went wrong ...!";
                                response.Status = false;
                            }

                        }
                    //}
                    //else
                    //{
                    //    response.Message = "Kindly Update Custom App....! ";
                    //    response.Status = false;
                    //}
                }

            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public Response UpdateUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id)
        {
            Response response = new Response();
            DataSet ds = new DataSet();


            MySqlParameter[] param = new MySqlParameter[5];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_category_id", MySqlDbType.VarChar); //VarChar
                    param[0].Value = obj_userapp_user_category.user_category_id;

                    param[1] = new MySqlParameter("p_user_category_path", MySqlDbType.VarChar);
                    param[1].Value = obj_userapp_user_category.user_category_path;

                    param[2] = new MySqlParameter("p_user_category_name", MySqlDbType.VarChar);
                    param[2].Value = obj_userapp_user_category.user_category_name;

                    param[3] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[3].Value = customer_id;

                    param[4] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
                    param[4].Value = "Update";

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_UpdateUserappUserCategory", param);

                }
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(ds.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Update UserappUserCategory Successfull  !! ";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(ds.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(ds.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }


            }

            catch (Exception ex)
            {

            }
            return response;
        }

        public DataTable GetAllUserappUserCategory(string subdomainname)
        {
            Response response = new Response();
            DataTable ds = new DataTable();

            MySqlParameter[] param = new MySqlParameter[1];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {

                    param[0] = new MySqlParameter("p_subdomainname", MySqlDbType.VarChar);
                    param[0].Value = subdomainname;
                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_GetAllUserappUserCategory", param);
                 
                }
                if (ds.Rows.Count != 0)
                {
                    if (ds.Rows.Count != 0)
                    {
                        response.Data = ds;
                        response.Message = "";
                        response.Status = true;
                    }
                    else
                    {
                        response.Data = "";
                        response.Message = "Data not Found...!";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Message = "Oops Something Went Wrong....!";
                    response.Status = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return ds;
        }

        //public Response AddUserappAppAccessCopy(userapp_app_access_copy obj_userapp_app_access_copy)
        //{
        //    Response response = new Response();
        //    DataSet dsetup = new DataSet();


        //    MySqlParameter[] param = new MySqlParameter[9];
        //    try
        //    {
        //        using MySqlConnection con = new MySqlConnection(connection);
        //        {
        //            param[0] = new MySqlParameter("p_user_category_id", MySqlDbType.VarChar); //VarChar
        //            param[0].Value = obj_userapp_app_access_copy.user_category_id;

        //            param[1] = new MySqlParameter("p_user_app_access", MySqlDbType.VarChar);
        //            param[1].Value = obj_userapp_app_access_copy.user_app_access;

        //            param[2] = new MySqlParameter("p_is_face_id_login_mandatory", MySqlDbType.Bool);
        //            param[2].Value = obj_userapp_app_access_copy.is_face_id_login_mandatory;

        //            param[3] = new MySqlParameter("p_is_new_user_upporval_mandatory", MySqlDbType.Bool);
        //            param[3].Value = obj_userapp_app_access_copy.is_new_user_upporval_mandatory;


        //            param[4] = new MySqlParameter("p_is_business_location_mandatory", MySqlDbType.Int64);
        //            param[4].Value = obj_userapp_app_access_copy.is_business_location_mandatory;


        //            param[5] = new MySqlParameter("p_additional_user_data_field_name", MySqlDbType.VarChar);
        //            param[5].Value = obj_userapp_app_access_copy.additional_user_data_field_name;

        //            param[6] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
        //            param[6].Value = obj_userapp_app_access_copy.customer_id;   //enty_by_user_id


        //            param[7] = new MySqlParameter("p_user_category_name", MySqlDbType.VarChar);
        //            param[7].Value = obj_userapp_app_access_copy.user_category_name;   //enty_by_user_id

        //            param[8] = new MySqlParameter("p_Action", MySqlDbType.VarChar);
        //            param[8].Value = "Insert";

        //            dsetup = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserappAppAccessCopy", param);

        //        }
        //        if (dsetup.Tables.Count > 0)
        //        {
        //            if (dsetup.Tables[0].Rows.Count > 0)
        //            {

        //                if (Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]) == "200")
        //                {

        //                    response.Data = "";

        //                    response.Message = "Add UserappAppAccessCopy successfully !! ";
        //                    response.Status = true;
        //                }
        //                else
        //                {
        //                    response.Message = Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]);
        //                    response.Status = Convert.ToInt32(dsetup.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
        //                }
        //            }
        //        }

        //    }

        //    catch (Exception ex)
        //    {

        //    }
        //    return response;
        //}

        public Response DeleteUserappUserCategoryById(string Customer_Id, string User_Category_Id, string User_Category_Name)
        {
            Response response = new Response();
            DataSet dsetup = new DataSet();


            MySqlParameter[] param = new MySqlParameter[3];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_Customer_Id", MySqlDbType.VarChar); //VarChar
                    param[0].Value = Customer_Id;

                    param[1] = new MySqlParameter("p_User_Category_Id", MySqlDbType.VarChar);
                    param[1].Value = User_Category_Id;

                    param[2] = new MySqlParameter("p_User_Category_Name", MySqlDbType.VarChar);
                    param[2].Value = User_Category_Name;



                    dsetup = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_DeleteUserappUserCategoryById", param);

                }
                if (dsetup.Tables.Count > 0)
                {
                    if (dsetup.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]) == "200")
                        {

                            response.Data = "";

                            response.Message = "Delete UserappUserCategoryById Successfull !! ";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = Convert.ToString(dsetup.Tables[0].Rows[0]["Message"]);
                            response.Status = Convert.ToInt32(dsetup.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {

            }
            return response;
        }




        public Response GetManifestFile(string subdomain)
        {

            Response response = new Response();
            DataSet dsetlogin = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_subdomain", MySqlDbType.VarChar);
                    param[0].Value = subdomain;
                    dsetlogin = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetSubdomain", param);
                }
                if(dsetlogin.Tables.Count != 0)
                {
                    string checkstatus = dsetlogin.Tables[0].Rows[0]["app_name"].ToString();
                    if(checkstatus != "500")
                    {

                    Manifest Objmanifest = new Manifest();
                    var url = "https://api.getbiz.app/customer-id";
                    Objmanifest.name = dsetlogin.Tables[0].Rows[0]["app_name"].ToString();
                    Objmanifest.short_name = dsetlogin.Tables[0].Rows[0]["app_name"].ToString();
                    Objmanifest.theme_color = dsetlogin.Tables[1].Rows[0]["title_bar_color"].ToString();
                    Objmanifest.background_color = dsetlogin.Tables[1].Rows[0]["title_bar_text_color"].ToString();
                    Objmanifest.display = "standalone";
                    Objmanifest.scope = "./";
                    Objmanifest.start_url = $"https://{subdomain}.getbiz.app/";
                    Objmanifest.icons = new List<Icon> { };
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-72x72.png",
                        sizes = "72x72",
                        type = "image/png",
                        purpose = "any"
                    });
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-96x96.png",
                        sizes = "96x96",
                        type = "image/png",
                        purpose = "any"
                    });
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-128x128.png",
                        sizes = "128x128",
                        type = "image/png",
                        purpose = "any"
                    });
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-144x144.png",
                        sizes = "144x144",
                        type = "image/png",
                        purpose = "any"
                    });
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-152x152.png",
                        sizes = "152x152",
                        type = "image/png",
                        purpose = "any"
                    });
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-192x192.png",
                        sizes = "192x192",
                        type = "image/png",
                        purpose = "any"
                    });
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-384x384.png",
                        sizes = "384x384",
                        type = "image/png",
                        purpose = "any"
                    });
                    Objmanifest.icons.Add(new Icon
                    {
                        src = $"{url}/icon/{subdomain}-icon-512x512.png",
                        sizes = "512x512",
                        type = "image/png",
                        purpose = "any"
                    });


                    response.Data = Objmanifest;
                    response.Message = "";
                    response.Status = true;

                    }
                    else
                    {
                        response.Data = "Data Not Found";
                        response.Message = "";
                        response.Status = false;
                    }
                }
                else
                {
                    response.Data = "Data Not Found";
                    response.Message = "";
                    response.Status = false;
                }

               


            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = Convert.ToInt32(dsetlogin.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;

        }




        public Response VerifySubdomain(string subdomain)
        {

            Response response = new Response();
            DataSet dsetlogin = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_subdomain", MySqlDbType.VarChar);
                    param[0].Value = subdomain;

                    dsetlogin = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_VerifySubdomainname", param);

                }
                string getcount = dsetlogin.Tables[0].Rows[0]["countstatus"].ToString();
                string Assignstatus = string.Empty;
                if (getcount == "0")
                {
                    Assignstatus = "Avaliable";
                }
                else if(string.IsNullOrEmpty(getcount))
                {
                    Assignstatus = "Something went wrong Kindly Contact Admin Team";

                }
                else
                {
                    Assignstatus = "Not Avaliable Check another Subdomain Name";
                }

                response.Data = Assignstatus;
                response.Message = "";
                response.Status = true;


            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = Convert.ToInt32(dsetlogin.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;

        }


        public Response GetSubdomainList()
        {

            Response response = new Response();
            DataSet dsetlogin = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                 
                    dsetlogin = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetSubdomainList", param);

                }
                response.Data = dsetlogin;
                response.Message = "";
                response.Status = true;
            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = Convert.ToInt32(dsetlogin.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;

        }
        public Response InsertSubscribe(newSubscriber sub)
        {

            Response response = new Response();
            DataSet dsetlogin = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[4];
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    param[0] = new MySqlParameter("p_User_id", MySqlDbType.Int64); //VarChar
                    param[0].Value = sub.user_id;

                    param[1] = new MySqlParameter("p_Endpoint", MySqlDbType.VarChar);
                    param[1].Value = sub.pushSubscription.Endpoint;

                    param[2] = new MySqlParameter("p_P256DH", MySqlDbType.VarChar);
                    param[2].Value = sub.pushSubscription.P256DH; 
                    param[3] = new MySqlParameter("p_Auth", MySqlDbType.VarChar);
                    param[3].Value = sub.pushSubscription.Auth;

                    dsetlogin = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertSubscribeDts", param);
                }
                if (dsetlogin.Tables[0].Rows[0]["Status"].ToString() == "200")
                {
                    response.Data = "Subscribe Added Successfull";
                    response.Message = "";
                    response.Status = true;
                }
                else
                {
                    response.Data = "Oops Something went wrong...!";
                    response.Message = "";
                    response.Status = false;
                }
               
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = Convert.ToInt32(dsetlogin.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;

        }


        public Response Updatemanifest(AssignManifestDetailsModal ObjManifest)
        {
          
            Response response = new Response();
            DataSet dsetlogin = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[15];
                {
                    using MySqlConnection con = new MySqlConnection(connection);
                    param[0] = new MySqlParameter("p_Customerid", MySqlDbType.VarChar); //VarChar
                    param[0].Value = ObjManifest.Customerid;

                    param[1] = new MySqlParameter("p_app_name", MySqlDbType.VarChar);
                    param[1].Value = ObjManifest.app_name;

                    param[2] = new MySqlParameter("p_app_sub_domain", MySqlDbType.VarChar);
                    param[2].Value = ObjManifest.app_sub_domain;
                    param[3] = new MySqlParameter("p_image_size72", MySqlDbType.VarChar);
                    param[3].Value = ObjManifest.app_icon_image_size_72x72;

                    param[4] = new MySqlParameter("p_image_size512", MySqlDbType.VarChar); //VarChar
                    param[4].Value = ObjManifest.app_icon_image_size_512x512;

                    param[5] = new MySqlParameter("p_image_size96", MySqlDbType.VarChar);
                    param[5].Value = ObjManifest.app_icon_image_size_96x96;

                    param[6] = new MySqlParameter("p_image_size128", MySqlDbType.VarChar);
                    param[6].Value = ObjManifest.app_icon_image_size_128x128;
                    param[7] = new MySqlParameter("p_image_size144", MySqlDbType.VarChar);
                    param[7].Value = ObjManifest.app_icon_image_size_144x144;


                    param[8] = new MySqlParameter("p_image_size152", MySqlDbType.Int64); //VarChar
                    param[8].Value = ObjManifest.app_icon_image_size_152x152;

                    param[9] = new MySqlParameter("p_image_size192", MySqlDbType.VarChar);
                    param[9].Value = ObjManifest.app_icon_image_size_192x192;

                    param[10] = new MySqlParameter("p_image_size384", MySqlDbType.VarChar);
                    param[10].Value = ObjManifest.app_icon_image_size_384x384;
                    param[11] = new MySqlParameter("p_image_sizebackgroundimage", MySqlDbType.VarChar);
                    param[11].Value = ObjManifest.background_image;
                    param[12] = new MySqlParameter("p_title_bar_color", MySqlDbType.Int64); //VarChar
                    param[12].Value = ObjManifest.title_bar_color;

                    param[13] = new MySqlParameter("p_title_bar_text_color", MySqlDbType.VarChar);
                    param[13].Value = ObjManifest.title_bar_text_color;

                    param[14] = new MySqlParameter("p_backgroundimg", MySqlDbType.VarChar);
                    param[14].Value = ObjManifest.background_image_text_colour;
               

                    dsetlogin = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_Updatemanifest", param);
                }
                if (dsetlogin.Tables[0].Rows[0]["Status"].ToString() == "200")
                {
                    response.Data = "Subscribe Added Successfull";
                    response.Message = "";
                    response.Status = true;
                }
                else
                {
                    response.Data = "Oops Something went wrong...!";
                    response.Message = "";
                    response.Status = false;
                }

            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = Convert.ToInt32(dsetlogin.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
            }
            return response;

        }





        public Response GetVerifyuser(UserLogin obj_userlogin)
        {
            Response response = new Response();

            if (!string.IsNullOrEmpty(obj_userlogin.password))
            {
                string assignpwd = SecureHelper.ECode(obj_userlogin.password);
                DataSet dsetcheckuser = new DataSet();
                try
                {
                    MySqlParameter[] param = new MySqlParameter[3];
                    {
                        using MySqlConnection con = new MySqlConnection(connection);

                        param[0] = new MySqlParameter("p_mobileNo", MySqlDbType.VarChar);
                        param[0].Value = obj_userlogin.mobileNo;

                        param[1] = new MySqlParameter("p_password", MySqlDbType.VarChar);
                        param[1].Value = assignpwd;
                        param[2] = new MySqlParameter("p_suddomainname", MySqlDbType.VarChar);
                        param[2].Value = obj_userlogin.suddomainname;


                        dsetcheckuser = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetUserVerifyDetails", param);

                    }
                 
                    if(dsetcheckuser.Tables.Count != 0)
                    {
                        if (dsetcheckuser.Tables[0].Rows.Count != 0)
                        {

                            string checkcustomapp = dsetcheckuser.Tables[2].Rows[0]["checkcustomapp"].ToString();
                            if (dsetcheckuser.Tables[1].Rows[0]["timestampcount"].ToString() == "0")
                            {
                                response.Data = "";
                                response.Message = "Kindly Update App Category & Custom App";
                                response.Status = false;

                            }
                            else if (dsetcheckuser.Tables[3].Rows[0]["user_category_update_timestamp"].ToString() != "" && checkcustomapp == "0")
                            {

                                string user_category_timestamp = dsetcheckuser.Tables[3].Rows[0]["user_category_update_timestamp"].ToString();
                             //  string custom_app_update_timestamp = dsetcheckuser.Tables[4].Rows[0]["custom_app_update_utc_timestamp"].ToString();
                               string custom_app_update_timestamp = "";
                                string userappstamp = dsetcheckuser.Tables[5].Rows[0]["user_app_update_time_stamp"].ToString();


                                string custid = dsetcheckuser.Tables[0].Rows[0]["custid"].ToString();
                                string user_id = dsetcheckuser.Tables[0].Rows[0]["user_id"].ToString();

                                DataSet checkutcds = new DataSet();

                                MySqlParameter[] checkverfiyutcparam = new MySqlParameter[4];
                                {
                                    using MySqlConnection con = new MySqlConnection(connection);

                                    checkverfiyutcparam[0] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                                    checkverfiyutcparam[0].Value = user_id;

                                    checkverfiyutcparam[1] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                                    checkverfiyutcparam[1].Value = custid;
                                    checkverfiyutcparam[2] = new MySqlParameter("p_usercategory_timestamp", MySqlDbType.VarChar);
                                    checkverfiyutcparam[2].Value = user_category_timestamp.Trim();

                                    checkverfiyutcparam[3] = new MySqlParameter("p_customapp_timestamp", MySqlDbType.VarChar);
                                    checkverfiyutcparam[3].Value = custom_app_update_timestamp.Trim();
                                    checkutcds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_Checkuseridutctimestamp", checkverfiyutcparam);

                                }



                                //MySqlParameter[] checkverfiyutcparam = new MySqlParameter[4];
                                //{
                                //    using MySqlConnection checkverfiyutcconn = new MySqlConnection(connection);

                                //    checkverfiyutcparam[0] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                                //    checkverfiyutcparam[0].Value = user_id;
                                //    checkverfiyutcparam[1] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                                //    checkverfiyutcparam[1].Value = custid;
                                //    checkverfiyutcparam[2] = new MySqlParameter("p_usercategory_timestamp", MySqlDbType.VarChar);
                                //    checkverfiyutcparam[2].Value = user_category_timestamp.Trim();
                                //    checkverfiyutcparam[3] = new MySqlParameter("p_customapp_timestamp", MySqlDbType.VarChar);
                                //    checkverfiyutcparam[3].Value = custom_app_update_timestamp.Trim();
                                //    checkutcds = SqlHelpher.ExecuteDataset(checkverfiyutcconn, CommandType.StoredProcedure, "SP_Checkuseridutctimestamp", checkverfiyutcparam);
                                //}
                                string verifyuser_category_timestamp = checkutcds.Tables[0].Rows[0]["user_category_update_utc_timestamp"].ToString();
                                string verifycustom_app_update_timestamp = checkutcds.Tables[0].Rows[0]["custom_app_update_utc_timestamp"].ToString();
                                string verifyuserappstamp = checkutcds.Tables[0].Rows[0]["user_app_update_utc_timestamp"].ToString();
                                if (!string.IsNullOrEmpty(verifyuserappstamp))
                                {
                                    if (user_category_timestamp.Trim() == verifyuser_category_timestamp.Trim() && userappstamp.Trim() == verifyuserappstamp.Trim())
                                    {
                                        response.Data = dsetcheckuser.Tables[0];
                                        response.Message = "";
                                        response.Status = true;
                                    }
                                    else
                                    {
                                        DataSet verifyutcds = new DataSet();

                                        MySqlParameter[] verfiyutcparam = new MySqlParameter[5];
                                        {
                                            using MySqlConnection verfiyutcconn = new MySqlConnection(connection);

                                            verfiyutcparam[0] = new MySqlParameter("p_user_category_timestamp", MySqlDbType.VarChar);
                                            verfiyutcparam[0].Value = user_category_timestamp.Trim();
                                            verfiyutcparam[1] = new MySqlParameter("p_custom_app_update_timestamp", MySqlDbType.VarChar);
                                            verfiyutcparam[1].Value = custom_app_update_timestamp.Trim();
                                            verfiyutcparam[2] = new MySqlParameter("p_userappstamp", MySqlDbType.VarChar);
                                            verfiyutcparam[2].Value = userappstamp.Trim();
                                            verfiyutcparam[3] = new MySqlParameter("p_custid", MySqlDbType.VarChar);
                                            verfiyutcparam[3].Value = custid;
                                            verfiyutcparam[4] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                                            verfiyutcparam[4].Value = user_id;
                                            verifyutcds = SqlHelpher.ExecuteDataset(verfiyutcconn, CommandType.StoredProcedure, "SP_UpdateUserUtcCategory", verfiyutcparam);
                                        }
                                        response.Data = dsetcheckuser.Tables[0];
                                        response.Message = "";
                                        response.Status = true;
                                    }


                                }
                                else
                                {
                                    response.Data = "";
                                    response.Message = "Kindly Update User App....!";
                                    response.Status = false;
                                }

                            }

                            else if (dsetcheckuser.Tables[3].Rows[0]["user_category_update_timestamp"].ToString() != "" && checkcustomapp != "0")
                            {

                                string user_category_timestamp = dsetcheckuser.Tables[3].Rows[0]["user_category_update_timestamp"].ToString();
                                string custom_app_update_timestamp = dsetcheckuser.Tables[4].Rows[0]["custom_app_update_utc_timestamp"].ToString();
                                string userappstamp = "";
                               // string userappstamp = dsetcheckuser.Tables[5].Rows[0]["user_app_update_time_stamp"].ToString();


                                string custid = dsetcheckuser.Tables[0].Rows[0]["custid"].ToString();
                                string user_id = dsetcheckuser.Tables[0].Rows[0]["user_id"].ToString();

                                DataSet checkutcds = new DataSet();
                                MySqlParameter[] checkverfiyutcparam = new MySqlParameter[4];
                                {
                                    using MySqlConnection conn = new MySqlConnection(connection);

                                    checkverfiyutcparam[0] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                                    checkverfiyutcparam[0].Value = user_id;
                                    checkverfiyutcparam[1] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                                    checkverfiyutcparam[1].Value = custid;
                                    checkverfiyutcparam[2] = new MySqlParameter("p_usercategory_timestamp", MySqlDbType.VarChar);
                                    checkverfiyutcparam[2].Value = user_category_timestamp.Trim();
                                    checkverfiyutcparam[3] = new MySqlParameter("p_customapp_timestamp", MySqlDbType.VarChar);
                                    checkverfiyutcparam[3].Value = custom_app_update_timestamp.Trim();
                                    checkutcds = SqlHelpher.ExecuteDataset(conn, CommandType.StoredProcedure, "SP_Checkuseridutctimestamp", checkverfiyutcparam);
                                }
                                string verifyuser_category_timestamp = checkutcds.Tables[0].Rows[0]["user_category_update_utc_timestamp"].ToString();
                                string verifycustom_app_update_timestamp = checkutcds.Tables[0].Rows[0]["custom_app_update_utc_timestamp"].ToString();
                                string verifyuserappstamp = checkutcds.Tables[0].Rows[0]["user_app_update_utc_timestamp"].ToString();
                                if (!string.IsNullOrEmpty(verifycustom_app_update_timestamp))
                                {
                                    if (user_category_timestamp.Trim() == verifyuser_category_timestamp.Trim() && custom_app_update_timestamp.Trim() == verifycustom_app_update_timestamp.Trim())
                                    {
                                        response.Data = dsetcheckuser.Tables[0];
                                        response.Message = "";
                                        response.Status = true;
                                    }
                                    else
                                    {
                                        DataSet verifyutcds = new DataSet();

                                        MySqlParameter[] verfiyutcparam = new MySqlParameter[5];
                                        {
                                            using MySqlConnection verfiyutcconn = new MySqlConnection(connection);

                                            verfiyutcparam[0] = new MySqlParameter("p_user_category_timestamp", MySqlDbType.VarChar);
                                            verfiyutcparam[0].Value = user_category_timestamp.Trim();
                                            verfiyutcparam[1] = new MySqlParameter("p_custom_app_update_timestamp", MySqlDbType.VarChar);
                                            verfiyutcparam[1].Value = custom_app_update_timestamp.Trim();
                                            verfiyutcparam[2] = new MySqlParameter("p_userappstamp", MySqlDbType.VarChar);
                                            verfiyutcparam[2].Value = verifyuserappstamp.Trim();
                                            verfiyutcparam[3] = new MySqlParameter("p_custid", MySqlDbType.VarChar);
                                            verfiyutcparam[3].Value = custid;
                                            verfiyutcparam[4] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                                            verfiyutcparam[4].Value = user_id;
                                            verifyutcds = SqlHelpher.ExecuteDataset(verfiyutcconn, CommandType.StoredProcedure, "SP_UpdateUserUtccustomappCategory", verfiyutcparam);
                                        }
                                        response.Data = dsetcheckuser.Tables[0];
                                        response.Message = "";
                                        response.Status = true;
                                    }


                                }
                                else
                                {
                                    response.Data = "";
                                    response.Message = "Kindly Update Custom App....!";
                                    response.Status = false;
                                }

                            }


                        }
                        else
                        {
                            response.Data = "";
                            response.Message = "Invalid Mobileno & Password .....!";
                            response.Status = false;
                        }
                    }
                    else
                    {
                        response.Data = "";
                        response.Message = "Invalid Subdomain Name ...!";
                        response.Status = false;
                    }

                   

                }

                catch (Exception ex)
                {
                    response.Message = ex.Message;
                    response.Status =false;
                }
                return response;
            }
            else
            {
                response.Message = "Enter the Password";
                response.Status = false;
                return response;
            }


        }




        public Response AddUserappCategorywiseappaccess(userapp_Categorywiseappaccess obj_userappCategorywiseappaccess)
        {
            Response response = new Response();
            DataSet dsetup = new DataSet();

            string additional_getster_data_field_name = JsonConvert.SerializeObject(obj_userappCategorywiseappaccess.additional_user_data_field_name);

            string app_id = JsonConvert.SerializeObject(obj_userappCategorywiseappaccess.app_id);

            MySqlParameter[] param = new MySqlParameter[8];
            try
            {
                using MySqlConnection con = new MySqlConnection(connection);
                {
                    param[0] = new MySqlParameter("p_user_category_id", MySqlDbType.VarChar); //VarChar
                    param[0].Value = obj_userappCategorywiseappaccess.user_category_id;

                    
                    param[1] = new MySqlParameter("p_is_face_id_login_mandatory", MySqlDbType.Bool);
                    param[1].Value = obj_userappCategorywiseappaccess.is_face_id_login_mandatory;

                    param[2] = new MySqlParameter("p_is_new_user_apporval_mandatory", MySqlDbType.Bool);
                    param[2].Value = obj_userappCategorywiseappaccess.is_new_user_apporval_mandatory;


                    param[3] = new MySqlParameter("p_is_business_location_mandatory", MySqlDbType.Bool);
                    param[3].Value = obj_userappCategorywiseappaccess.is_business_location_mandatory;


                    param[4] = new MySqlParameter("p_additional_user_data_field_name", MySqlDbType.JSON);
                    param[4].Value = additional_getster_data_field_name;

                    param[5] = new MySqlParameter("p_app_id", MySqlDbType.JSON);
                    param[5].Value = app_id;


                    param[6] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[6].Value = obj_userappCategorywiseappaccess.customer_id;   //enty_by_user_id


                    param[7] = new MySqlParameter("p_userapp_category_utc", MySqlDbType.VarChar);
                    param[7].Value = obj_userappCategorywiseappaccess.userapp_category_utc;   //enty_by_user_id
                

                    dsetup = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertUserCategorywiseappaccess", param);

                }
                if (dsetup.Tables.Count > 0)
                {
                    if (dsetup.Tables[0].Rows.Count > 0)
                    {

                        if (Convert.ToString(dsetup.Tables[0].Rows[0]["Status"]) == "200")
                        {

                            response.Data = "";
                            response.Message = "Add UserappCategorywiseappaccess Successfull !! ";
                            response.Status = true;
                        }
                        else
                        {
                            response.Message = "Oops Something Went wrong...!";
                            response.Status = Convert.ToInt32(dsetup.Tables[0].Rows[0]["Status"]) != -1 ? true : false;
                        }
                    }
                }

            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status =  false;
            }
            return response;
        }



        public Response GetCategoryAdditionalDataFieldName(string User_category_id,string Customer_id)
        {
            Response response = new Response();
            // string getster_category_id1 = JsonConvert.SerializeObject(getster_category_id);

            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_User_category_id", MySqlDbType.VarChar);
                    param[0].Value = User_category_id;
                    param[1] = new MySqlParameter("p_Subdomainname", MySqlDbType.VarChar);
                    param[1].Value = Customer_id;


                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetCategoryAdditionalDataFieldName", param);
                }
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        response.Data = ds;
                        response.Message = "";
                        response.Status = true;
                    }
                    else
                    {
                        response.Data = "";
                        response.Message = "Data not Found...!";
                        response.Status = false;
                    }

                }
                else
                {
                    response.Data = "";
                    response.Message = "Invalid Subdomain Name ...!";
                    response.Status = false;
                }
             
            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }


        public DataSet Get_category_and_app_access(string Category_id,string Customer_id)
        {
            Response response = new Response();

            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_Category_id", MySqlDbType.VarChar);
                    param[0].Value = Category_id;
                    param[1] = new MySqlParameter("p_Customer_id", MySqlDbType.VarChar);
                    param[1].Value = Customer_id;

                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetCategory_and_app_access", param);

                }
                if (ds.Tables.Count != 0)
                {
                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        response.Data = ds;
                        response.Message = "";
                        response.Status = true;
                    }
                    else
                    {
                        response.Data = "";
                        response.Message = "Data not Found...!";
                        response.Status = false;
                    }

                }
                else
                {
                    response.Data = "";
                    response.Message = "Invalid Subdomain Name ...!";
                    response.Status = false;
                }



            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = false;
            }


            return ds;

        }




        public Response Getlaunchfavourite_apps(string customer_id, string userid)
        {
            Response response = new Response();

            DataTable ds = new DataTable();
            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[0].Value = customer_id;
                    param[1] = new MySqlParameter("p_userid", MySqlDbType.VarChar);
                    param[1].Value = userid;
                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_Getlaunchfavouriteapps", param);

                }
                response.Data = ds;
                response.Message = "Success";
                response.Status = true;
            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = false;
            }


            return response;

        }



        public Response Getlaunchrecent_apps(string customer_id, string userid)
        {
            Response response = new Response();

            DataTable ds = new DataTable();
            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[0].Value = customer_id;
                    param[1] = new MySqlParameter("p_userid", MySqlDbType.VarChar);
                    param[1].Value = userid;
                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_Getlaunchrecentapps", param);

                }

                response.Data = ds;
                response.Message = "Success";
                response.Status = true;
            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = false;
            }


            return response;

        }



        public DataSet Getlaunchscreen_apps(string customer_id, string userid)
        {
            Response response = new Response();

            DataSet ds = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[2];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[0].Value = customer_id;
                    param[1] = new MySqlParameter("p_userid", MySqlDbType.VarChar);
                    param[1].Value = userid;
                    ds = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_Getlaunchscreenapps", param);

                }
                return ds;

            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }


            return ds;

        }



        public Response AddFavouriteAppScreens(FavouriteAppScreens objfavourite)
        {

            Response response = new Response();
            DataSet dsetlogin = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[6];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_app_id", MySqlDbType.VarChar);
                    param[0].Value = objfavourite.app_id;

                    param[1] = new MySqlParameter("p_is_custom_app", MySqlDbType.VarChar);
                    param[1].Value = objfavourite.is_custom_app;

                    param[2] = new MySqlParameter("p_app_icon_image_path", MySqlDbType.VarChar);
                    param[2].Value = objfavourite.app_icon_image_path;

                    param[3] = new MySqlParameter("p_app_icon_name", MySqlDbType.VarChar);
                    param[3].Value = objfavourite.app_icon_name;

                    param[4] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[4].Value = objfavourite.customer_id;

                    param[5] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                    param[5].Value = objfavourite.user_id;

                    dsetlogin = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertFavouriteAppScreens", param);

                }
                string getstatus = Convert.ToString(dsetlogin.Tables[0].Rows[0]["Status"]);

                if (getstatus == "200")
                {
                    response.Data = "";
                    response.Message = "Added FavouriteApps Successfully..";
                    response.Status = true;
                }
                else if (getstatus == "505")
                {
                    response.Data = "";
                    response.Message = "Already Exist..";
                    response.Status = true;
                }
                else
                {
                    response.Message = "Something Went Wrong Oops Problem ..!";
                    response.Status = false;
                }


            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status =false;
            }
            return response;

        }


        public Response AddRecentAppScreens(RecentAppScreens objrecent)
        {

            Response response = new Response();
            DataSet dsetlogin = new DataSet();
            try
            {
                MySqlParameter[] param = new MySqlParameter[6];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_app_id", MySqlDbType.VarChar);
                    param[0].Value = objrecent.app_id;

                    param[1] = new MySqlParameter("p_is_custom_app", MySqlDbType.VarChar);
                    param[1].Value = objrecent.is_custom_app;

                    param[2] = new MySqlParameter("p_app_icon_image_path", MySqlDbType.VarChar);
                    param[2].Value = objrecent.app_icon_image_path;

                    param[3] = new MySqlParameter("p_app_icon_name", MySqlDbType.VarChar);
                    param[3].Value = objrecent.app_icon_name;
                    param[4] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[4].Value = objrecent.customer_id;

                    param[5] = new MySqlParameter("p_user_id", MySqlDbType.VarChar);
                    param[5].Value = objrecent.user_id;

                    dsetlogin = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_InsertRecentAppScreens", param);

                }
                string getstatus = Convert.ToString(dsetlogin.Tables[0].Rows[0]["Status"]);

                if (getstatus == "200")
                {
                    response.Data = "";
                    response.Message = "Add RecentApps Successfully....!";
                    response.Status = true;
                }
                else
                {
                    response.Message = "Something Went Wrong Oops Problem ..!";
                    response.Status = false;
                }


            }

            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;

        }


        public Response GetLaunchScreenApps(string customer_id)
        {
            Response response = new Response();

            DataTable ds = new DataTable();
            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[0].Value = customer_id;
                  
                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_Getuserappslaunchscreen", param);

                }
                response.Data = ds;
                response.Message = "Success";
                response.Status = true;
            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = false;
            }


            return response;

        }


        public Response GetBusinessCategoriesApps(string customer_id)
        {
            Response response = new Response();

            DataTable ds = new DataTable();
            try
            {
                MySqlParameter[] param = new MySqlParameter[1];
                {
                    using MySqlConnection con = new MySqlConnection(connection);

                    param[0] = new MySqlParameter("p_customer_id", MySqlDbType.VarChar);
                    param[0].Value = customer_id;
                   
                    ds = SqlHelpher.ExecuteDataTable(con, CommandType.StoredProcedure, "SP_Getbusinesscategoriesapps", param);

                }
                response.Data = ds;
                response.Message = "Success";
                response.Status = true;
            }

            catch (Exception ex)
            {
                response.Message = "Failure";
                response.Status = false;
            }


            return response;

        }



    }
}
