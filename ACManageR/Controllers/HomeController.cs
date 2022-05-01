using ACManageR.Entities;
using ACManageR.ExtentionMethods;
using ACManageR.Models;
using ACManageR.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ACManageR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ACManageRDBContext _database;

        public HomeController(ILogger<HomeController> logger, ACManageRDBContext database)
        {
            _logger = logger;
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LogIn(LogInVM input)
        {
            if (!this.ModelState.IsValid)
                return View(input);
            var user = _database.Users.Where(u => u.Username == input.Username).FirstOrDefault();
            if (user is null)
            {
                this.ModelState.AddModelError("authError", "Such user does not exist!");
                return View(new LogInVM());
            }
            if (user.PasswordHash != HashingMethods.Hash(input.Password, user.PasswordSalt))
            {
                this.ModelState.AddModelError("authError", "Wrong password dumb dumb!");
                return View(input);
            }
            _database.SaveChanges();
            HttpContext.Session.SetObject("loggedUser", user);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(LogInVM input)
        {
            if (!this.ModelState.IsValid)
                return View(input);
            var salt = HashingMethods.CreateSalt(32);
            var user = new Users() { Username = input.Username};
            user.PasswordHash = HashingMethods.Hash(input.Password, salt);
            user.PasswordSalt = salt;
            user.RoleId = (int)RolesEnum.Customer;
            _database.Users.Add(user);
            _database.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("loggedUser");
            return RedirectToAction("Index", "Home");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
