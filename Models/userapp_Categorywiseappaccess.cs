using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace getbiz_launch_app.Models
{
    public class userapp_Categorywiseappaccess
    {
        public string user_category_id { set; get; }
        public bool is_face_id_login_mandatory { set; get; }
        public bool is_new_user_apporval_mandatory { set; get; }
        public bool is_business_location_mandatory { set; get; }
        public List<additional_user_data_field_name1> additional_user_data_field_name { get; set; }

     //   public string additional_user_data_field_name { set; get; }   //json
        public List<app_ids> app_id { get; set; }

        public string customer_id { set; get; }   //json
        public string userapp_category_utc { get; set; }

    }

    public class app_ids
    {
        public string user_app_category_id { get; set; }
        public string app_id { get; set; }
        public bool is_custom_app { get; set; }


    }

    public class additional_user_data_field_name1
    {

        public string headerKey { get; set; }
        public string headerValue { get; set; }
        public string isMandatory { get; set; }

    }
    public class user_categoryids
    {
        public string user_app_category_Id { set; get; }
        public List<user_categoryappids> data { get; set; }

    }
    public class user_categoryappids
    {
        public string user_app_id { set; get; }
    }

    public class userapp_categoryadditional_data
    {
        public string additional_user_data_field_name { get; set; }
        public bool is_face_id_login_mandatory { get; set; }
        public bool is_new_user_upporval_mandatory { get; set; }
        public bool is_business_location_mandatory { get; set; }


    }



}
