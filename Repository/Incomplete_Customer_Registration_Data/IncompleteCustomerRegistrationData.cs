using getbiz_launch_app.Getbiz_DbContext;
using getbiz_launch_app.Helpers;
using getbiz_launch_app.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace getbiz_launch_app.Repository.Incomplete_Customer_Registration_Data
{
    public class IncompleteCustomerRegistrationData : IIncompleteCustomerRegistrationData
    {
        public readonly LaunchAppDB_DbContext _DbContext;
        public IncompleteCustomerRegistrationData(LaunchAppDB_DbContext DbContext, IConfiguration configuration)
        {
            _DbContext = DbContext;

        }

        public Response AddIncompleteCustomerRegistrationData(incomplete_customer_registration_data_Step1 obj_incomplete_customer_registration_data,incomplete_customer_registration_data_Step2 obj_data_step2,incomplete_customer_registration_data objMain,incomplete_customer_registration_data_Step3 obj_incomplete_customer_registration_data_Step3)
        {
            
            Response response = new Response();
            try
            {
                if (obj_incomplete_customer_registration_data.id == 0)
                {
                    incomplete_customer_registration_data obj = new incomplete_customer_registration_data();
                   //  var business_category_ids = JsonConvert.SerializeObject(obj_incomplete_customer_registration_data.business_category_ids);


                    obj.first_name = obj_incomplete_customer_registration_data.first_name;
                    obj.last_name = obj_incomplete_customer_registration_data.last_name;
                    obj.login_mobile_no = obj_incomplete_customer_registration_data.login_mobile_no;
                    obj.user_password = SecureHelper.ECode(obj_incomplete_customer_registration_data.user_password); ;
                    obj.business_category_ids = obj_incomplete_customer_registration_data.business_category_ids;
                    obj.customer_location_latitude = obj_incomplete_customer_registration_data.customer_location_latitude;
                    obj.customer_location_logitude = obj_incomplete_customer_registration_data.customer_location_logitude;
                    _DbContext.Attach(obj);

                    _DbContext.Entry(obj).Property(p => p.first_name).IsModified = true;
                    _DbContext.Entry(obj).Property(p => p.last_name).IsModified = true;
                    _DbContext.Entry(obj).Property(p => p.login_mobile_no).IsModified = true;
                    _DbContext.Entry(obj).Property(p => p.user_password).IsModified = true;
                    _DbContext.Entry(obj).Property(p => p.business_category_ids).IsModified = true;
                    _DbContext.Entry(obj).Property(p => p.customer_location_latitude).IsModified = true;
                    _DbContext.Entry(obj).Property(p => p.customer_location_logitude).IsModified = true;
                    _DbContext.SaveChanges();

                    response.Message = "Data Saved successfully !!";
                    response.Status = true;
                    response.Data = (obj.id);
                }
                else if (obj_incomplete_customer_registration_data.id != 0 && obj_data_step2.app_name !=null  
                    && obj_data_step2.app_sub_domain != null &&obj_data_step2.title_bar_color != null && obj_data_step2.title_bar_text_color != null
                    &&obj_data_step2.background_image_text_colour != null  && obj_data_step2 != null)   // doubt
                {

                   // var launch_screen_app_ids_jsonvalue = JsonConvert.SerializeObject(obj_data_step2.launch_screen_app_ids);

                    try
                    {
                        objMain.id = obj_data_step2.id;
                        objMain.app_sub_domain = obj_data_step2.app_sub_domain;
                        objMain.app_name = obj_data_step2.app_name;
                        objMain.title_bar_color = obj_data_step2.title_bar_color;
                        objMain.title_bar_text_color = obj_data_step2.title_bar_text_color;
                        objMain.background_image_text_colour = obj_data_step2.background_image_text_colour;

                    //    objMain.launch_screen_app_ids = launch_screen_app_ids_jsonvalue;
                        objMain.launch_screen_app_ids = obj_data_step2.launch_screen_app_ids;

                        _DbContext.Attach(objMain);
                        _DbContext.Entry(objMain).Property(p => p.app_sub_domain).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_name).IsModified = true;

                        _DbContext.Entry(objMain).Property(p => p.background_image).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_72x72).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_96x96).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_128x128).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_144x144).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_152x152).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_192x192).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_384x384).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.app_icon_image_size_512x512).IsModified = true;

                        _DbContext.Entry(objMain).Property(p => p.title_bar_color).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.title_bar_text_color).IsModified = true;
                        _DbContext.Entry(objMain).Property(p => p.background_image_text_colour).IsModified = true;

                        _DbContext.Entry(objMain).Property(p => p.launch_screen_app_ids).IsModified = true;

                        _DbContext.SaveChanges();

                        response.Message = "Data Saved successfully !!";
                        response.Status = true;
                        response.Data = (objMain.id);


                    }
                    catch (Exception ex)
                    {
                        response.Message = ex.Message+ "Data Saved to failed !!";
                        response.Status = false;
                    }
                    return response;

                }

                else if (obj_incomplete_customer_registration_data.id != 0  && obj_incomplete_customer_registration_data_Step3 != null)
                {
                    try
                    {
                        GetSetDatabase Obj_GetSetDatabase = new GetSetDatabase();
                        var result = Obj_GetSetDatabase.UpdateIncompleteRegister(obj_incomplete_customer_registration_data_Step3);
                        response = result;
                    }
                    catch (Exception ex)
                    {
                        response.Message = "Data Saved to failed !!";
                        response.Status = false;
                    }
                    return response;

                }


            }
            catch (Exception ex)
            {
                response.Message = "Data Saved to failed !!";
                response.Status = false;
            }
                return response;        
        }














    }
}
