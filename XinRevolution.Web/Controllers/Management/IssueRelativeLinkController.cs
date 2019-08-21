//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using XinRevolution.Web.Services.Management;

//namespace XinRevolution.Web.Controllers.Management
//{
//    [Area("Management")]
//    public class IssueRelativeLinkController : Controller
//    {
//        private readonly IssueRelativeLinkManagementService _service;

//        public IssueRelativeLinkController(IssueRelativeLinkManagementService service)
//        {
//            _service = service;
//        }

//        public IActionResult Index(long issueId)
//        {
//            var data = _service.FindByIssueID(issueId);

//            return View(data);
//        }

//        public IActionResult Create()
//        {
            
//            return View();
//        }

//        public IActionResult Delete()
//        {
//            return View();
//        }
//    }
//}