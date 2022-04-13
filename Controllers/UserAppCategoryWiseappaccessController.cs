using getbiz_launch_app.Models;
using getbiz_launch_app.Repository.UserAppCategoryWiseappaccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace getbiz_launch_app.Controllers
{
    [ApiController]
    public class UserAppCategoryWiseappaccessController : ControllerBase
    {

        private readonly IUserAppCategoryWiseappaccessRepository _UserAppCategoryWiseappaccessRepository;

        public UserAppCategoryWiseappaccessController(IUserAppCategoryWiseappaccessRepository UserAppCategoryWiseappaccessRepository)
        {
            _UserAppCategoryWiseappaccessRepository = UserAppCategoryWiseappaccessRepository;
        }




        [AllowAnonymous]
        [HttpPost]
        [Route("api/AddUserappCategorywiseappaccess")]
        public IActionResult AddUserappCategorywiseappaccess(userapp_Categorywiseappaccess obj_userappCategorywiseappaccess)
        {
            try
            {
                var messages = _UserAppCategoryWiseappaccessRepository.AddUserappCategorywiseappaccess(obj_userappCategorywiseappaccess);
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
        [Route("api/GetCategoryDataFieldName")]
        public IActionResult GetCategoryAdditionalDataFieldName(string User_category_id,string Subdomain)
        {
            try
            {
                var messages = _UserAppCategoryWiseappaccessRepository.GetCategoryAdditionalDataFieldName(User_category_id, Subdomain);
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
        [Route("api/Get_category_and_app_access")]
        public IActionResult Get_category_and_app_access(string Category_id,string Customer_id)
        {
            try
            {
                Response response = new Response();

                if (!string.IsNullOrEmpty(Category_id))
                {
                    var messages = _UserAppCategoryWiseappaccessRepository.Get_category_and_app_access(Category_id,Customer_id);
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
