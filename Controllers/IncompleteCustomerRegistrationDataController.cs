using Microsoft.Extensions.Configuration;
using getbiz_launch_app.Models;
using getbiz_launch_app.Repository.Incomplete_Customer_Registration_Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class IncompleteCustomerRegistrationDataController : ControllerBase
    {
        private IConfiguration _configuration;

        private IIncompleteCustomerRegistrationData _incompleteCustomerRegistrationData;

        public IncompleteCustomerRegistrationDataController(IIncompleteCustomerRegistrationData incompleteCustomerRegistrationData, IConfiguration configuration)
        {
            _incompleteCustomerRegistrationData = incompleteCustomerRegistrationData;
            _configuration = configuration;

        }


        // [AllowAnonymous]
        [HttpPost]
        [Route("api/AddIncompleteCustomerRegistrationData")]

        // [ModelBinder(BinderType = typeof(FormDataJsonModelBinder))]
       // IList<json_field_name> launch_screen_app_ids,
        public IActionResult AddIncompleteCustomerRegistrationData(incomplete_customer_registration_data_Step1 obj_incomplete_customer_registration_data_step1,   incomplete_customer_registration_data_Step2 obj_incomplete_customer_registration_data_step2, incomplete_customer_registration_data_Step3 obj_incomplete_customer_registration_data_Step3)
        {
            try
            {           
               // string getster_data_field_values = JsonConvert.SerializeObject(launch_screen_app_ids);

                incomplete_customer_registration_data objget = new incomplete_customer_registration_data();
        
                if (!string.IsNullOrEmpty(obj_incomplete_customer_registration_data_step2.app_sub_domain))
                {
                    objget.app_icon_image_size_72x72 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(72, 72)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_72", obj_incomplete_customer_registration_data_step2.id);
                    objget.app_icon_image_size_96x96 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(96, 96)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_96", obj_incomplete_customer_registration_data_step2.id);
                    objget.app_icon_image_size_128x128 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(128, 128)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_128", obj_incomplete_customer_registration_data_step2.id);
                    objget.app_icon_image_size_144x144 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(144, 144)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_144", obj_incomplete_customer_registration_data_step2.id);
                    objget.app_icon_image_size_152x152 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(152, 152)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_152", obj_incomplete_customer_registration_data_step2.id);
                    objget.app_icon_image_size_192x192 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(192, 192)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_192", obj_incomplete_customer_registration_data_step2.id);
                    objget.app_icon_image_size_384x384 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(384, 384)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_384", obj_incomplete_customer_registration_data_step2.id);
                    objget.app_icon_image_size_512x512 = saveImage(resizeImage(obj_incomplete_customer_registration_data_step2.app_icon_image_size_512x512, new Size(512, 512)), obj_incomplete_customer_registration_data_step2.app_sub_domain + "_icon_512", obj_incomplete_customer_registration_data_step2.id);
                    objget.background_image = saveImage(convertImage(obj_incomplete_customer_registration_data_step2.background_image), obj_incomplete_customer_registration_data_step2.app_sub_domain, obj_incomplete_customer_registration_data_step2.id);

                   // objget.launch_screen_app_ids = getster_data_field_values;
                }
                var messages = _incompleteCustomerRegistrationData.AddIncompleteCustomerRegistrationData(obj_incomplete_customer_registration_data_step1, obj_incomplete_customer_registration_data_step2, objget, obj_incomplete_customer_registration_data_Step3);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        protected string saveImage(byte[] image, string name,int id)
        {
            string LiveServerpath = _configuration.GetSection("LiveUserapp").Value;
            string pathname = LiveServerpath+"\\"+ id;
            string uniqueFileName = name + ".png";

            bool exists = System.IO.Directory.Exists(pathname);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(pathname);
            }
            using (MemoryStream mem = new MemoryStream(image))
            {
                using (var yourImage = Image.FromStream(mem))
                {
                    var filepath = pathname + "\\" + uniqueFileName; 
                    yourImage.Save(filepath, ImageFormat.Png);
                }
            }
            return uniqueFileName;
        }  

       
        protected byte[] resizeImage(IFormFile imgToResize, Size size)
        {
            using (var ms = new MemoryStream())
            {
                imgToResize.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var contents = new Bitmap(new MemoryStream(fileBytes));
                var img = (Image)(new Bitmap(contents, size));
                ImageConverter converter = new ImageConverter();
                ms.Dispose();
                return (byte[])converter.ConvertTo(img, typeof(byte[]));
            }
        }

        protected static byte[] convertImage(IFormFile imgToResize)
        {
            using (var ms = new MemoryStream())
            {
                imgToResize.CopyTo(ms);
                var fileBytes = ms.ToArray();
                ms.Dispose();
                return (byte[])fileBytes;
            }
        }



















    }


}
