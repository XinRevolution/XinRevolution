using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Entity.Model;
using XinRevolution.Repository.Interface;
using XinRevolution.Web.Models.MetaData.Management;
using XinRevolution.Web.Services.Management;

namespace XinRevolution.Web.Controllers.Management
{
    [Area("Management")]
    public class UserController : Controller
    {
        private readonly UserMnagementService _service;

        public UserController(UserMnagementService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.Find();

            return View(data);
        }

        public IActionResult Create()
        {
            var data = _service.FindMD();

            return View(data);
        }

        [HttpPost]
        public IActionResult Create(UserMD data)
        {
            var result = false;

            if (ModelState.IsValid)
            {
                result = _service.Create(data);

                if (result)
                    return RedirectToAction("Index", "User");
            } 

            return View(data);
        }

        public IActionResult Update(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UserMD user)
        {
            return View();
        }

        public IActionResult Delete(long id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(UserMD id)
        {
            return View();
        }
    }
}