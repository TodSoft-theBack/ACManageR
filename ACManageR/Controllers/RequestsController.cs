using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACManageR.ExtentionMethods;
using ACManageR.Entities;
using ACManageR.ActionFilters;
using ACManageR.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ACManageR.Controllers
{
    [AuthenticationFilterAttribute]
    public class RequestsController : Controller
    {
        private ACManageRDBContext _database;
        private IWebHostEnvironment _hostEnvironment;
        public RequestsController(ACManageRDBContext database, IWebHostEnvironment hostEnvironment)
        {
            _database = database;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");
            ViewBag.AllRequests = _database.Requests.Include(r => r.Status).ToList();
            return View();
        }

        public IActionResult MakeRequest()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeRequest(MakeRequestVM input)
        {
            if (!this.ModelState.IsValid)
                return View(input);
            var loggedUser = HttpContext.Session.GetObject<Users>("loggedUser");
            var request = new Requests()
            {
                Name = input.Name,
                Description = input.Description,
                Address = input.Address,
                UserId = loggedUser.Id
            };
            if (!(input.Picture is null))
            {
                string id = Guid.NewGuid().ToString();
                string fileName = Path.Combine(_hostEnvironment.WebRootPath,"RequestImages", id + Path.GetExtension(input.Picture.FileName));
                input.Picture.CopyTo(new FileStream(fileName, FileMode.Create));
                request.Picture = id + Path.GetExtension(input.Picture.FileName);
            }
            _database.Requests.Add(request);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
