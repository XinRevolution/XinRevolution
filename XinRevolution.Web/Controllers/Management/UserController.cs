using Microsoft.AspNetCore.Mvc;
using XinRevolution.Web.Models.Management.MetaData;
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
            var data = _service.FindMetaData();

            return View(data);
        }

        [HttpPost]
        public IActionResult Create(UserMD data)
        {
            var result = _service.Create(data);

            if (result.Status)
                return RedirectToAction("Index", "User", new { Area = "Management" });

            ViewBag.ErrorMsg = result.Message;
            return View(result.Data);
        }

        public IActionResult Update(long id)
        {
            var data = _service.FindMetaData(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Update(UserMD data)
        {
            var result = _service.Update(data);

            if (result.Status)
                return RedirectToAction("Index", "User", new { Area = "Management" });

            ViewBag.ErrorMsg = result.Message;
            return View(result.Data);
        }

        public IActionResult Delete(long id)
        {
            var data = _service.FindMetaData(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Delete(UserMD data)
        {
            var result = _service.Delete(data);

            if (result.Status)
                return RedirectToAction("Index", "User", new { Area = "Management" });

            ViewBag.ErrorMsg = result.Message;
            return View(result.Data);
        }
    }
}