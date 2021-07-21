using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using project.Data;
using project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactContext _context;
        public IDataAccess _dataAccess;
        public IBackstage _backstage;
        public HomeController(ContactContext context, IDataAccess dataAccess,IBackstage backstage)
        {
            _context = context;
            _dataAccess = dataAccess;
            _backstage = backstage;
        }

        public IActionResult Index()
        {
            var getnew = _dataAccess.GetNews3(3);

            return View(getnew);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                
                string Name=Request.Form["Name"];
                string Phone = Request.Form["Phone"];
                string Address = Request.Form["Address"];
                string ContactMessage = Request.Form["ContactMessage"];
                _backstage.CreateContactUs(Name,Phone,Address,ContactMessage);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
