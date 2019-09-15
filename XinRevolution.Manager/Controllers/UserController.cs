using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Services;

namespace XinRevolution.Manager.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.FindAll();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserMD data)
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UserMD data)
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(UserMD data)
        {
            return View();
        }
    }
}