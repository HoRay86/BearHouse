using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Data;

namespace project.Controllers
{
    public class NewsController : Controller
    {
        public IDataAccess _dataAccess;

        public NewsController(IDataAccess dataAccess) //讓控制器可以使用 預先設計的方法
        {
            _dataAccess = dataAccess;
        }
        public IActionResult Index()
        {
            var allnew = _dataAccess.GetNews();
            return View(allnew);
        }
        
        public IActionResult Event1Index(int Id)
        {
            var news= _dataAccess.News(Id);
            return View(news);
        }
    }
}