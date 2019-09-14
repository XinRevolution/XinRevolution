using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XinRevolution.Manager.Services;

namespace XinRevolution.Manager.Controllers
{
    public class UserController : Controller
    {

        public UserController(UserService service)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}