using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XinRevolution.Controllers.Official
{
    [Area("Official")]
    public class IssueController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(long id)
        {
            return PartialView("_Detail");
        }
    }
}