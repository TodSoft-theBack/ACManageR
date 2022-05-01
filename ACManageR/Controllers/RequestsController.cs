using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACManageR.ExtentionMethods;
using ACManageR.Entities;
using ACManageR.ActionFilters;
using ACManageR.ViewModels;

namespace ACManageR.Controllers
{
    [AuthenticationFilterAttribute]
    public class RequestsController : Controller
    {
        private ACManageRDBContext _database;
        public RequestsController(ACManageRDBContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            var loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");
            ViewBag.AllRequests = _database.Requests.ToList();
            return View();
        }

        public IActionResult MakeRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeRequest(MakeRequestVM input)
        {
            return View();
        }
    }
}
