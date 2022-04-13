using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Models
{
    public class Manifest
    {
        public string name { get; set; }
        public string short_name { get; set; }
        public string theme_color { get; set; }
        public string background_color { get; set; }
        public string display { get; set; }
        public string scope { get; set; }
        public string start_url { get; set; }
        public List<Icon> icons { get; set; }
    }

    public class Icon
    {
        public string src { get; set; }
        public string sizes { get; set; }
        public string type { get; set; }
        public string purpose { get; set; }
    }

    public class ResultManifest
    {
        public int app_id { get; set; }
        public string app_name { get; set; }
        public string app_sub_domain { get; set; }
        public string app_icon_image_size_72x72 { get; set; }
        public string app_icon_image_size_96x96 { get; set; }
        public string app_icon_image_size_128x128 { get; set; }
        public string app_icon_image_size_144x144 { get; set; }
        public string app_icon_image_size_152x152 { get; set; }
        public string app_icon_image_size_192x192 { get; set; }
        public string app_icon_image_size_384x384 { get; set; }
        public string app_icon_image_size_512x512 { get; set; }
        public string background_image { get; set; }
        public string title_bar_color { get; set; }
        public string title_bar_text_color { get; set; }

    }

    public class UpdateManifestDetailsModal
    {
        public int id { set; get; }
        public string Customerid { set; get; }
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
        //  public IList<json_field_name> launch_screen_app_ids { set; get; }
    }
    public class AssignManifestDetailsModal
    {
        public int id { set; get; }

        public string Customerid { set; get; }
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
    
    }



}
