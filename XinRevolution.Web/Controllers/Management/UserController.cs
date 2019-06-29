using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace XinRevolution.Web.Controllers.Management
{
    [Area("Management")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}