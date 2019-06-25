using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Web.Models.MetaData.Management;

namespace XinRevolution.Web.Controllers.Management
{
    [Area("Management")]
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserMD data = new UserMD();

            return View(data);
        }

        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(UserMD user)
        {
            if (!string.IsNullOrEmpty(user.Account) && !string.IsNullOrEmpty(user.Password))
                return RedirectToAction("Index", "Home");

            ViewBag.ErrorMsg = "請輸入帳號密碼";
            return View(user);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}