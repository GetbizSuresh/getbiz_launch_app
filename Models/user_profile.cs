using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace getbiz_launch_app.Models
{
    public class user_profile
    {

        [Key]
        public int user_id { get; set; }
        public string login_mobile_no { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string additional_user_data_field_values { get; set; }  //json
        public string about_user { get; set; }
        public string biz_card_company_details { get; set; }  //json
        public string biz_card_mobile_no { get; set; }
        public string biz_card_phone_no { get; set; }
        public string biz_card_website { get; set; }
        public string biz_card_email_id { get; set; }
        public string biz_card_address { get; set; }
        public string biz_card_address_gps { get; set; }
        public string face_recognition_approval_data { get; set; }
        public string user_registration_approval_date { get; set; }
        public string user_profile_update_date { get; set; }
        public string user_registration_timestamp { get; set; }
        public string Subdomianname { get; set; }
        public string customer_id { get; set; }

        
        public List<user_category_ids> user_category_id { get; set; }

      //  public string user_category_id { set; get; }  
        public string user_password { get; set; }
        public int user_registration_approval_status { get; set; }
        public string face_recognition_filenames { get; set; }
        public string last_login_timestamp { get; set; }

    }

    public class user_category_ids
    {
        [Key]
        public string user_category_id { get; set; }

    }

    public class UserLogin
    {
        public string suddomainname { get; set; }
        public string mobileNo { get; set; } // foreign Key
        public string password { get; set; }
    }



    public class FavouriteAppScreens
    {
        public string customer_id { get; set; }
        public string user_id { get; set; }
        public string app_id { get; set; } 
        public bool is_custom_app { get; set; } 
        public string app_icon_image_path { get; set; }
        public string app_icon_name { get; set; }

    }

    public class RecentAppScreens
    {
        public string customer_id { get; set; }
        public string user_id { get; set; }
        public string app_id { get; set; }
        public bool is_custom_app { get; set; } 
        public string app_icon_image_path { get; set; }
        public string app_icon_name { get; set; }
    }


    public class launch_category_json
    {
        public string app_id { set; get; }
        public bool is_custom_app { set; get; }     
        public string app_icon_image_path { set; get; }
        public string app_icon_name { set; get; }
        public string app_location_within_the_category_id { set; get; }

    }


    public class launch_categoryname
    {
        public string user_app_category_name { set; get; }
        public List<launch_category_json> data { get; set; }


    }





}
