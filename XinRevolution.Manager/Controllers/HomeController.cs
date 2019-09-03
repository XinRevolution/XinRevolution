using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Models;
using XinRevolution.Manager.Services;

namespace XinRevolution.Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _service;

        public HomeController(UserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            UserMD data = new UserMD();

            return View(data);
        }

        [HttpPost]
        public IActionResult Login(UserMD data)
        {
            var result = _service.Login(data);

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View(data);
            }

            // TODO : 加入認證邏輯

            return RedirectToAction("Index", "User");
        }

        public IActionResult Logout()
        {
            // TODO : 加入認證清除邏輯

            return RedirectToAction("Login", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
