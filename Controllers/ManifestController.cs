using getbiz_launch_app.Models;
using getbiz_launch_app.Repository.Manifest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManifestController : ControllerBase
    {
        private IConfiguration _configuration;

        private IManifestRepository _manifestrepository;

        public ManifestController(IManifestRepository manifestrepository, IConfiguration configuration)
        {
            _manifestrepository = manifestrepository;
            _configuration = configuration;

        }


        [HttpGet("{file}")]
        public IActionResult GetManifestFile(string file)
        {

            try
            {
                string subdomain = file.Split("-")[0];

                var messages = _manifestrepository.GetManifestFile(subdomain);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpGet("assets/{type}/{file}")]
        public IActionResult GetAssetsImage(string type, string file)
        {
            try
            {
                string[] sub = file.Split("-");
                string subdomain = sub[0];
                string asset = "";
                if (type == "icon")
                {
                    asset = $"manifest_data.app_icon_image_size_{sub[sub.Length - 1].Split(".")[0]}";
                }
                else
                {
                    asset = "launch_screen_data.background_image";
                }
                using (MySqlConnection connection = new MySqlConnection(_configuration["ConnectionStrings:Default"]))
                {
                    connection.Open();
                    string sql = $@"SELECT {asset} FROM manifest_data JOIN launch_screen_data ON launch_screen_data.app_name = manifest_data.app_name WHERE manifest_data.app_sub_domain = @app_sub_domain";
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@app_sub_domain", subdomain);
                    var reader = command.ExecuteScalar();
                    if (reader == null) return NotFound("not found");
                    string reader1 = _configuration["UploadPath"] + (string)reader;
                    byte[] img = System.IO.File.ReadAllBytes(reader1);
                    connection.Close();
                    return File(img, "image/png");
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


        [HttpGet("list")]
        public IActionResult GetSubdomainList()
        {
            try
            {
                var messages = _manifestrepository.GetSubdomainList();
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }

        [HttpGet]
        [Route("VerifySubdomain")]
        public IActionResult VerifySubdomain(string Subdomainname)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(Subdomainname))
                {
                    var messages = _manifestrepository.VerifySubdomain(Subdomainname);
                    if (messages == null)
                    {
                        return NotFound();
                    }
                    return Ok(messages);

                }
                else
                {
                    response.Message = "Must have a Single Value";
                    response.Status = false;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }





        [HttpPut("Updatemanifest")]
        public IActionResult Updatemanifest(UpdateManifestDetailsModal ObjManifest)
        {
            try
            {
                AssignManifestDetailsModal ObjAssign = new AssignManifestDetailsModal();
                if (!string.IsNullOrEmpty(ObjManifest.app_sub_domain) && !string.IsNullOrEmpty(ObjManifest.Customerid))
                {
                    ObjAssign.app_icon_image_size_72x72 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(72, 72)), ObjManifest.app_sub_domain + "_icon_72", ObjManifest.id);
                    ObjAssign.app_icon_image_size_96x96 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(96, 96)), ObjManifest.app_sub_domain + "_icon_96", ObjManifest.id);
                    ObjAssign.app_icon_image_size_128x128 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(128, 128)), ObjManifest.app_sub_domain + "_icon_128", ObjManifest.id);
                    ObjAssign.app_icon_image_size_144x144 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(144, 144)), ObjManifest.app_sub_domain + "_icon_144", ObjManifest.id);
                    ObjAssign.app_icon_image_size_152x152 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(152, 152)), ObjManifest.app_sub_domain + "_icon_152", ObjManifest.id);
                    ObjAssign.app_icon_image_size_192x192 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(192, 192)), ObjManifest.app_sub_domain + "_icon_192", ObjManifest.id);
                    ObjAssign.app_icon_image_size_384x384 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(384, 384)), ObjManifest.app_sub_domain + "_icon_384", ObjManifest.id);
                    ObjAssign.app_icon_image_size_512x512 = saveImage(resizeImage(ObjManifest.app_icon_image_size_512x512, new Size(512, 512)), ObjManifest.app_sub_domain + "_icon_512", ObjManifest.id);
                    ObjAssign.background_image = saveImage(convertImage(ObjManifest.background_image), ObjManifest.app_sub_domain, ObjManifest.id);

                    // objget.launch_screen_app_ids = getster_data_field_values;
                }

                ObjAssign.app_name = ObjManifest.app_name;
                ObjAssign.app_sub_domain = ObjManifest.app_sub_domain;
                ObjAssign.Customerid = ObjManifest.Customerid;
                ObjAssign.title_bar_color = ObjManifest.title_bar_color;
                ObjAssign.title_bar_text_color = ObjManifest.title_bar_text_color;
                ObjAssign.background_image_text_colour = ObjManifest.background_image_text_colour;

                var messages = _manifestrepository.Updatemanifest(ObjAssign);
                if (messages == null)
                {
                    return NotFound();
                }

                return Ok(messages);

            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

        }



        protected string saveImage(byte[] image, string name, int id)
        {
            string LiveServerpath = _configuration.GetSection("LiveUserapp").Value;
            string pathname = LiveServerpath + "\\" + id;
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
