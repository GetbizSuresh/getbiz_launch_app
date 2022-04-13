using getbiz_launch_app.Models;
using getbiz_launch_app.Repository.User_Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _UserProfileRepository;
        public UserProfileController(IUserProfileRepository UserProfileRepository)
        {
            _UserProfileRepository = UserProfileRepository;
        }

 
        [HttpPost]
        [Route("api/AddUserProfile")]
        public IActionResult AddUserProfile(user_profile obj_user_profile)
        {
            try
            {
                if (!string.IsNullOrEmpty(obj_user_profile.Subdomianname))
                {
                    var messages = _UserProfileRepository.AddUserProfile(obj_user_profile);
                    if (messages == null)
                    {
                        return NotFound();
                    }
                    return Ok(messages);

                }
                else
                {
                    return Ok("Subdomainname Cannot be Empty...!");
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/GetUserRegistrationApprovalStatusFieldBased")]
        public IActionResult GetUserRegistrationApprovalStatusFieldBased(string customer_id, Int64 user_registration_approval_status)
        {
            try
            {
                var messages = _UserProfileRepository.GetUserRegistrationApprovalStatusFieldBased(customer_id, user_registration_approval_status);
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




        [AllowAnonymous]
        [HttpPut]

        [Route("api/UpdateUserRegistrationApprovalStatus")]
        public IActionResult UpdateUserRegistrationApprovalStatus(string Customet_Id, Int64 User_Registration_Approval_Status, Int64 User_Id , Int64 From_Id)
        {
            try
            {
                var messages = _UserProfileRepository.UpdateUserRegistrationApprovalStatus(Customet_Id, User_Registration_Approval_Status, User_Id, From_Id);
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



        [AllowAnonymous]
        [HttpGet]

        [Route("api/GetUserProfile")]
        public IActionResult GetUserProfile(string Customet_Id, Int64 User_Id)
        {
            try
            {
                var messages = _UserProfileRepository.GetUserProfile(Customet_Id, User_Id);
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




        [AllowAnonymous]
        [HttpPut]

        [Route("api/UpdateUserProfile")]
        public IActionResult UpdateUserProfile(user_profile obj_user_profile)
        {
            try
            {
                var messages = _UserProfileRepository.UpdateUserProfile(obj_user_profile);
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




        [AllowAnonymous]
        [HttpPut]

        [Route("api/UpdateUserProfileMobileNumber")]
        public IActionResult UpdateUserProfileMobileNumber(string Customet_Id, string Login_Mobile_No, Int64 User_Id )
        {
            try
            {
                var messages = _UserProfileRepository.UpdateUserProfileMobileNumber(Customet_Id, Login_Mobile_No, User_Id);
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


        [HttpPost]
        [Route("Verifyuser")]
        public IActionResult GetVerifyuser(UserLogin obj_userlogin)
        {
            try
            {
                if (obj_userlogin.mobileNo == null) return Unauthorized("Token Unauthorized");
                //DataSet dsetcheckuser = new DataSet();
                //string assignpwd = SecureHelper.ECode(obj_userlogin.password);

                //MySqlParameter[] param = new MySqlParameter[2];
                //{
                //    string connection = configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

                //    using MySqlConnection con = new MySqlConnection(connection);

                //    param[0] = new MySqlParameter("p_mobileNo", MySqlDbType.VarChar);
                //    param[0].Value = obj_userlogin.mobileNo;

                //    param[1] = new MySqlParameter("p_password", MySqlDbType.VarChar);
                //    param[1].Value = assignpwd;

                //    dsetcheckuser = SqlHelpher.ExecuteDataset(con, CommandType.StoredProcedure, "SP_GetUserVerifyDetails", param);

                //}
                //string getstatus = Convert.ToString(dsetcheckuser.Tables[2].Rows[0]["Status"]);

                //string getsterid = Convert.ToString(dsetcheckuser.Tables[1].Rows[0]["getsterid"]);

                //string verifytimestamp = Convert.ToString(dsetcheckuser.Tables[0].Rows[0]["getster_category_update_utc_time_stamp"]).Trim();

                //string tokenString = string.Empty;
                //tokenString = BuildToken();
                //string authkey = "Bearer " + tokenString;
                var messages = _UserProfileRepository.GetVerifyuser(obj_userlogin);
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



        [HttpGet]
        [Route("Getlaunchrecent_apps")]
        public IActionResult Getlaunchrecent_apps(string customer_id,string userid)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(customer_id) && !string.IsNullOrEmpty(userid))
                {
                    var messages = _UserProfileRepository.Getlaunchrecent_apps(customer_id, userid);
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


        [HttpGet]
        [Route("Getlaunchfavourite_apps")]
        public IActionResult Getlaunchfavourite_apps(string customer_id, string userid)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(customer_id) && !string.IsNullOrEmpty(userid))
                {
                    var messages = _UserProfileRepository.Getlaunchfavourite_apps(customer_id, userid);
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

        [HttpGet]
        [Route("Getlaunchscreen_apps")]
        public IActionResult Getlaunchscreen_apps(string customer_id, string userid)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(customer_id) && !string.IsNullOrEmpty(userid))
                {
                    var messages = _UserProfileRepository.Getlaunchscreen_apps(customer_id, userid);
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



        [HttpPost]
        [Route("FavouriteAppScreens")]
        public IActionResult FavouriteAppScreens(FavouriteAppScreens objfavourite)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(objfavourite.app_id))
                {
                    var messages = _UserProfileRepository.AddFavouriteAppScreens(objfavourite);
                    if (messages == null)
                    {
                        return NotFound();
                    }
                    return Ok(messages);

                }
                else
                {
                    response.Message = "Must have a app_id Value";
                    response.Status = false;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("RecentAppScreens")]
        public IActionResult RecentAppScreens(RecentAppScreens objrecent)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(objrecent.app_id))
                {
                    var messages = _UserProfileRepository.AddRecentAppScreens(objrecent);
                    if (messages == null)
                    {
                        return NotFound();
                    }
                    return Ok(messages);

                }
                else
                {
                    response.Message = "Must have a Getster_Id Value";
                    response.Status = false;
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("GetLaunchScreenApps")]
        public IActionResult GetLaunchScreenApps(string customer_id)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(customer_id) )
                {
                    var messages = _UserProfileRepository.GetLaunchScreenApps(customer_id);
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

        [HttpGet]
        [Route("GetBusinessCategoriesApps")]
        public IActionResult GetBusinessCategoriesApps(string customer_id)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(customer_id))
                {
                    var messages = _UserProfileRepository.GetBusinessCategoriesApps(customer_id);
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


    }
}
