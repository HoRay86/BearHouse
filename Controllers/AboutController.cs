using Microsoft.AspNetCore.Mvc;
using project.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;


namespace project.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutUsContext _context;
        public IDataAccess _dataAccess;
        public AboutController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        // GET: AboutUs
        public IActionResult Index()
        {
            string id = "1";
            var data = _dataAccess.AboutUs(id);
            return View(data);
        }

    }
}
