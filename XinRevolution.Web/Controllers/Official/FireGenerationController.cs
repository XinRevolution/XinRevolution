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
        public IActionResult Intro()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Character(long id)
        {
            return PartialView("_Character");
        }

        public IActionResult Conception()
        {
            return View();
        }

        public IActionResult ConceptionContent(long id)
        {
            return PartialView("_ConceptionContent");
        }

        public IActionResult StoryLine()
        {
            return View();
        }

        public IActionResult Season()
        {
            return View();
        }

        public IActionResult Chapter()
        {
            return PartialView("_Chapter");
        }

        public IActionResult Comic()
        {
            return PartialView("_Comic");
        }
    }
}