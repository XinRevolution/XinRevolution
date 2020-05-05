using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Services;

namespace XinRevolution.Manager.Controllers
{
    public class IssueController : Controller
    {
        private readonly IssueService _service;

        public IssueController(IssueService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var result = _service.FindAll();

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View("Error");
            }

            return View(result.Data);
        }
        public IActionResult Create()
        {
            var result = _service.FindMetaData();

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View("Error");
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IssueMD data)
        {
            var result = _service.Create(data);

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View(result.Data);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var result = _service.FindMetaData(id);

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View("Error");
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(IssueMD data)
        {
            var result = _service.Update(data);

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View(result.Data);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _service.FindMetaData(id);

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View("Error");
            }

            return View(result.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(IssueMD data)
        {
            var result = _service.Delete(data);

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View(result.Data);
            }

            return RedirectToAction("Index");
        }
    }
}