using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Web.Models.Management.MetaData;
using XinRevolution.Web.Services.Management;

namespace XinRevolution.Web.Controllers.Management
{
    [Area("Management")]
    public class IssueController : Controller
    {
        private readonly IssueManagementService _service;

        public IssueController(IssueManagementService service)
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
            var data = _service.FindMetaData();

            return View(data);
        }

        [HttpPost]
        public IActionResult Create(IssueMD data)
        {
            var result = _service.Create(data);

            if (result.Status)
                return RedirectToAction("Index", "Issue", new { Area = "Management" });

            ViewBag.ErrorMsg = result.Message;
            return View(result.Data);
        }

        public IActionResult Update(long id)
        {
            var data = _service.FindMetaData(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Update(IssueMD data)
        {
            var result = _service.Update(data);

            if (result.Status)
                return RedirectToAction("Index", "Issue", new { Area = "Management" });

            ViewBag.ErrorMsg = result.Message;
            return View(result.Data);
        }

        public IActionResult Delete(long id)
        {
            var data = _service.FindMetaData(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(IssueMD data)
        {
            var result = _service.Delete(data);

            if (result.Status)
                return RedirectToAction("Index", "Issue", new { Area = "Management" });

            ViewBag.ErrorMsg = result.Message;
            return View(result.Data);
        }
    }
}