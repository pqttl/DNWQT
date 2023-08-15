using DNQT.AdminApp.Services;
using DNQT.ViewModels.Admin.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNQT.AdminApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApiClient _userApiClient;
        private readonly IConfiguration _configuration;

        public UserController(IUserApiClient iApiClient, IConfiguration configuration)
        {
            _userApiClient = iApiClient;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> IARLogin()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View();
        }

        [HttpGet]
        public IActionResult IARRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IARRegister(CreateUser_ViewModel mRequest)
        {
            if (!ModelState.IsValid)
            {
                return View(mRequest);
            }

            //ModelState.AddModelError("", "abc");
            //return View();

            var strToken = await _userApiClient.TStrAuthenticate(mRequest);

            //var userPrincipal = ClaimsPrincipalValidateToken(strToken);
            //var authProperties = new AuthenticationProperties
            //{
            //    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            //    IsPersistent = false
            //};
            //await HttpContext.SignInAsync(
            //            CookieAuthenticationDefaults.AuthenticationScheme,
            //            userPrincipal,
            //            authProperties);

            string strTemp = nameof(HomeController);
            string strController = strTemp.Substring(0, strTemp.LastIndexOf("Controller"));
            return RedirectToAction(nameof(HomeController.Index), strController);
        }

    }
}
