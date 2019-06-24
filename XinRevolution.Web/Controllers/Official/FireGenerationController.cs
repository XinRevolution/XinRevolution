using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XinRevolution.Controllers.Official
{
    [Area("Official")]
    public class FireGenerationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Intro()
        {
            return View();
        }

        public IActionResult Character(string role)
        {
            ViewBag.PartialPath = string.Format("_{0}", role);

            return View();
        }

        public IActionResult Timeline()
        {
            return View();
        }

        public IActionResult Season()
        {
            return View();
        }

        public IActionResult Comic(string comic)
        {
            return PartialView(comic);
        }

        public IActionResult Questionnaire(long id)
        {
            return PartialView("_Questionnaire");
        }

        [HttpPost]
        public IActionResult Questionnaire()
        {
            return Json(new { });
        }

        public IActionResult Conception()
        {
            return View();
        }

        public IActionResult ConceptionContent(long id)
        {
            return PartialView();
        }
    }
}