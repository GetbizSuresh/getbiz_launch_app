using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Models
{
    public class userapp_user_category
    {
        [Key]

        [MaxLength(100)]
        public string user_category_id { set; get; }
        [MaxLength(1000)]
        public string user_category_path { set; get; }
        [MaxLength(100)]
        public string user_category_name { set; get; }
     
    }
}
