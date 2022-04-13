using getbiz_launch_app.Models;
using getbiz_launch_app.Repository.Userapp_App_AccessCopy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;  
namespace getbiz_launch_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserappAppAccessCopyController : ControllerBase
    {
        private readonly IUserappAppAccessCopyRepository _UserappAppAccessCopyRepository;

        public UserappAppAccessCopyController(IUserappAppAccessCopyRepository UserappAppAccessCopyRepository)
        {
            _UserappAppAccessCopyRepository = UserappAppAccessCopyRepository;
        }




        //[AllowAnonymous]
        //[HttpPost]
        //[Route("api/AddUserappCategorywiseappaccess")]
        //public IActionResult AddUserappCategorywiseappaccess(userapp_Categorywiseappaccess obj_userappCategorywiseappaccess)
        //{
        //    try
        //    {
        //        var messages = _UserappAppAccessCopyRepository.AddUserappCategorywiseappaccess(obj_userappCategorywiseappaccess);
        //        if (messages == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(messages);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest();
        //    }
        //}







    }
}