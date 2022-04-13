using getbiz_launch_app.Models;
using getbiz_launch_app.Repository.Userapp_User_Category;
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
    public class UserappUserCategoryController : ControllerBase
    {

        private readonly IUserappUserCategoryRepository _userappUserCategoryRepository;
        public UserappUserCategoryController(IUserappUserCategoryRepository userappUserCategoryRepository)
        {
            _userappUserCategoryRepository = userappUserCategoryRepository;
        }


        [HttpPost]

        [Route("api/AddUserappUserCategory")]
        public IActionResult AddUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id, string userapp_category_utc)
        {
            try
            {
                if(!string.IsNullOrEmpty(userapp_category_utc) && !string.IsNullOrEmpty(customer_id))
                {
                    var messages = _userappUserCategoryRepository.AddUserappUserCategory(obj_userapp_user_category, customer_id, userapp_category_utc);
                    if (messages == null)
                    {
                        return NotFound();
                    }
                    return Ok(messages);
                }
                else
                {
                    return Ok("Kindly Check Customerid & Utc Timestamp");
                }
               

              
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpPut]

        [Route("api/UpdateUserappUserCategory")]
        public IActionResult UpdateUserappUserCategory(userapp_user_category obj_userapp_user_category, string customer_id)
        {
            try
            {
                var messages = _userappUserCategoryRepository.UpdateUserappUserCategory(obj_userapp_user_category, customer_id);
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

        [Route("api/GetAllUserappUserCategory")]
        public IActionResult GetAllUserappUserCategory(string subdomainname)
        {
            try
            {
                var messages = _userappUserCategoryRepository.GetAllUserappUserCategory(subdomainname);
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







        [HttpDelete]

        [Route("api/DeleteUserappUserCategoryById")]
        public IActionResult DeleteUserappUserCategoryById(string Customer_Id, string User_Category_Id,string User_Category_Name)
        {
            try
            {
                var messages = _userappUserCategoryRepository.DeleteUserappUserCategoryById(Customer_Id, User_Category_Id, User_Category_Name);
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













    }
}
