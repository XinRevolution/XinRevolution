using Microsoft.AspNetCore.Mvc;
using XinRevolution.Manager.MetaData;
using XinRevolution.Manager.Services;

namespace XinRevolution.Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _service;

        public HomeController(UserService service)
        {
            _service = service;
        }

        public IActionResult Login()
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
        public IActionResult Login(UserMD data)
        {
            var result = _service.Login(data);

            if (!result.Status)
            {
                ViewBag.ErrMessage = result.Message;

                return View(data);
            }

            // TODO : 加入認證邏輯

            return RedirectToAction("Index", "User");
        }

        public IActionResult Logout()
        {
            // TODO : 加入認證清除邏輯

            return RedirectToAction("Login", "Home");
        }
    }
}
