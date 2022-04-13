using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Models
{
    public class user_login_data
    {
        [Key]
        public int user_id { set; get; }
        [MaxLength(15)]
        public string login_mobile_no { set; get; }
        [MaxLength(100)]
        public string user_password { set; get; }
        [DefaultValue(0)]
        public int user_registration_approval_status { set; get; } 
        public string face_recognition_filenames { set; get; }  //json 

        [Column(TypeName = "longtext")]
        public string authkey { set; get; }
        public string last_login_timestamp { set; get; }
    }
}
