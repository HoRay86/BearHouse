using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class RoomsController : Controller
    {
        public IDataAccess _dataAccess;
        public RoomsController(IDataAccess dataAccess) //讓控制器可以使用 預先設計的方法
        {
            _dataAccess = dataAccess;
        }
        public IActionResult Roomselect()
        {
            return View();
        }
        public IActionResult Singleroom(int Id) //若方法內有一變數則需傳入一變數
        {
            var introductionroom = _dataAccess.roomIntroduction(Id);
            
            return View(introductionroom);
        }
        public IActionResult Roomsmasterpage()
        {
            return View();
        }

        public IActionResult Singleindex()
        {
            return View();
        }
        public IActionResult Roomselectindex()
        {
            return View();
        }
        public IActionResult Tripleindex()
        {
            return View();
        }
        public IActionResult Quadruplerindex()
        {
            return View();
        }
    }
}
