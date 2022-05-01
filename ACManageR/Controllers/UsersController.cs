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
            ViewBag.RoleOptions = _database.Roles.Select(r => new SelectListItem(r.RoleType, r.Id.ToString())).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserVM input)
        {
            if (!this.ModelState.IsValid)
                return View(input);
            if (!(_database.Users.Where(u => u.Username == input.Username).FirstOrDefault() is null))
            {
                this.ModelState.AddModelError("Username", "Such user already exists!");
                return View(new LogInVM());
            }
            var salt = HashingMethods.CreateSalt(32);
            var user = new Users()
            {
                Username = input.Username,
                PasswordSalt = salt,
                PasswordHash = HashingMethods.Hash(input.Password, salt),
                RoleId = input.RoleId
            };
            _database.Users.Add(user);
            _database.SaveChanges();
            return Index();
        }
        public IActionResult DeleteUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteUser(int id)
        {

            return Index();
        }
        public IActionResult EditUser()
        {
            ViewBag.RoleOptions = _database.Roles.Select(r => new SelectListItem(r.RoleType, r.Id.ToString())).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult EditUser(int id)
        {
            if (!this.ModelState.IsValid)
                return View();
            
            return Index();
        }
    }
}
