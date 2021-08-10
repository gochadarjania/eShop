using eShop.Admin.Models;
using eShop.ApplicationService.ServiceInterfaces;
using eShop.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShop.Admin.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        IUserApplicationService _userApplicationService;

        public AuthController(IUserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginOut()
        {
                HttpContext.Session.Clear();
                return Redirect("/");
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
           var responseCore = _userApplicationService.Login(new LoginDTO()
            {
                Email = loginModel.Email,
                PasswordHash = loginModel.PasswordHash
            });

            if (responseCore.Messages.Count==0)
            {
                HttpContext.Session.SetString("SessionID", responseCore.SessionID.ToString());
                HttpContext.Session.SetString("UserName", loginModel.Email);
                return Redirect("/");
            }

            return View(responseCore.Messages);
        }
    }
}
