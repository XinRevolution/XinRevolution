using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Web.Models.Management.MetaData;
using XinRevolution.Web.Services.Management;

namespace XinRevolution.Web.Controllers.Management
{
    [Area("Management")]
    public class HomeController : Controller
    {
        private readonly UserMnagementService _service;

        public HomeController(UserMnagementService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var data = _service.FindMetaData();

            return View(data);
        }

        [HttpPost]
        [AllowAnonymous]
        [AutoValidateAntiforgeryToken]
        public IActionResult Login(UserMD user)
        {
            var result = _service.Login(user);

            if (result.Status || true)
                return RedirectToAction("Index", "User", new { Area = "Management" });

            ViewBag.ErrorMsg = result.Message;
            return View(user);
        }
    }
}