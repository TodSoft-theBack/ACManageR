using ACManageR.ActionFilters;
using ACManageR.Entities;
using ACManageR.ExtentionMethods;
using ACManageR.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACManageR.Controllers
{
    [AuthenticationFilterAttribute]
    public class UsersController : Controller
    {
        private ACManageRDBContext _database;
        public UsersController(ACManageRDBContext database)
        {
            _database = database;
        }
        public IActionResult Index()
        {
            var loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");
            ViewBag.AllUsers = _database.Users.Include(u => u.Role).Where(u => u.Id != loggedUser.Id).ToList();
            return View();
        }
        public IActionResult CreateUser()
        {
            
            return View(new CreateUserVM() { RoleOptions = _database.Roles.Select(r => new SelectListItem(r.RoleType, r.Id.ToString())).ToList()});
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserVM input)
        {

            return Index();
        }
    }
}
