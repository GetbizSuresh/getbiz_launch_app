using Castle.MicroKernel.SubSystems.Conversion;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Models
{
    public class incomplete_customer_registration_data
    {
        [Key]
        public int id { set; get; }
        [MaxLength(15)]
        public string login_mobile_no { set; get; }
        [MaxLength(100)]
        public string first_name { set; get; }
        [MaxLength(100)]
        public string last_name { set; get; }
        public string customer_location_latitude { set; get; }
        public string customer_location_logitude { set; get; }
        [MaxLength(100)]
        public string user_password { set; get; }
        public string business_category_ids { set; get; }
        // ----------------------------------------------------------------
        [MaxLength(100)]
        public string app_sub_domain { set; get; }
        [MaxLength(20)]
        public string app_name { set; get; }
        public string app_icon_image_size_72x72 { set; get; }
        public string app_icon_image_size_512x512 { set; get; }
        public string app_icon_image_size_96x96 { set; get; }
        public string app_icon_image_size_128x128 { set; get; }
        public string app_icon_image_size_144x144 { set; get; }
        public string app_icon_image_size_152x152 { set; get; }
        public string app_icon_image_size_192x192 { set; get; }
        public string app_icon_image_size_384x384 { set; get; }
        public string background_image { set; get; }
        [MaxLength(17)]
        public string title_bar_color { set; get; }
        [MaxLength(17)]
        public string title_bar_text_color { set; get; }
        [MaxLength(17)]
        public string background_image_text_colour { set; get; }

         public string launch_screen_app_ids { set; get; }               //Json

        // -------------------------------------------------------
        [MaxLength(50)]
        public string registered_business_name { set; get; }
        [MaxLength(50)]
        public string address_line_1 { set; get; }
        [MaxLength(50)]
        public string address_line_2 { set; get; }
        [MaxLength(25)]
        public string city_town_village { set; get; }
        [MaxLength(25)]
        public string district_county { set; get; }
        [MaxLength(25)]
        public string state_province { set; get; }
        [MaxLength(50)]
        public string country { set; get; }
        [MaxLength(10)]
        public string pin_code { set; get; }
        [MaxLength(15)]
        public string business_phone_number { set; get; }
        public bool business_phone_number_verified { set; get; }
        [MaxLength(15)]
        public string key_contact_mobile_number { set; get; }
        public bool key_contact_mobile_number_verified { set; get; }
        [MaxLength(50)]
        public string official_email_id { set; get; }
        public int number_of_employees { set; get; }
        [MaxLength(50)]
        public string country_code { set; get; }
        [MaxLength(50)]
        public string map_location_display_name { set; get; }
        public string gps_coordinates { set; get; }
        [MaxLength(255)]
        public string google_place_id { set; get; }
    }
    public class incomplete_customer_registration_data_Step1
    {
        [Key]
        public int id { set; get; }
        public string login_mobile_no { set; get; }

        [MaxLength(100)]
        public string first_name { set; get; }

        [MaxLength(100)]
        public string last_name { set; get; }

        [MaxLength(100)]
        public string user_password { set; get; }
       //  public List<business_category> business_category_ids { get; set; }   

        public string business_category_ids { set; get; }              
        public string customer_location_latitude { set; get; }
        public string customer_location_logitude { set; get; }

    }
    public class incomplete_customer_registration_data_Step2
    {
        [Key]
        public int id { set; get; }
        [MaxLength(100)]
        public string app_sub_domain { set; get; }
        [MaxLength(100)]
        public string app_name { set; get; }
        public IFormFile app_icon_image_size_512x512 { set; get; }
        public IFormFile background_image { set; get; }
        [MaxLength(100)]
        public string title_bar_color { set; get; }
        [MaxLength(100)]
        public string title_bar_text_color { set; get; }
        [MaxLength(100)]
       public string background_image_text_colour { set; get; }
     //   public List<launch_screen_app> launch_screen_app_ids { get; set; }
        public string launch_screen_app_ids { set; get; }
      //  public IList<json_field_name> launch_screen_app_ids { set; get; }
    }
    public class launch_screen_app
    {
        public string launch_screen_app_id { set; get; }
    }

    public class business_category
    {
        public string business_category_id { set; get; }
    }




    public class incomplete_customer_registration_data_Step3
    {
     [Key]
    public int id { set; get; }
    [MaxLength(50)]
    public string registered_business_name { set; get; }
    [MaxLength(50)]
    public string address_line_1 { set; get; }
    [MaxLength(50)]
    public string address_line_2 { set; get; }
    [MaxLength(25)]
    public string city_town_village { set; get; }
    [MaxLength(25)]
    public string district_county { set; get; }
    [MaxLength(25)]


    public string state_province { set; get; }
    [MaxLength(50)]
    public string country { set; get; }
    [MaxLength(10)]
    public string pin_code { set; get; }
    public string business_phone_number { set; get; }
    public bool business_phone_number_verified { set; get; }
    public string key_contact_mobile_number { set; get; }
    public bool key_contact_mobile_number_verified { set; get; }


    [MaxLength(50)]
    public string official_email_id { set; get; }
    public int number_of_employees { set; get; }
        [MaxLength(30)]
     public string country_code { set; get; }


     [MaxLength(50)]
     public string map_location_display_name { set; get; }
    public string gps_coordinates { set; get; }
    [MaxLength(255)]
     public string google_place_id { set; get; }

    }

    //public class json_field_name
    //{
    //    public string launch_screenids { get; set; }
    //}




}
