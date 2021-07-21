using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class NewManagementController : Controller
    {
        public IBackstage _Backstage;
        public NewManagementController(IBackstage backstage)
        {
            _Backstage = backstage;
        }

        public IActionResult Index()
        {
            var datanews=_Backstage.GetNews();
            return View(datanews);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNew(IFormCollection form)
        {
            string Name = Request.Form["Name"];
            string Photo = Request.Form["Photo"];
            string Date = Request.Form["Date"];
            string Title = Request.Form["Title"];
            string Introduction = Request.Form["Introduction"];
            string Text = Request.Form["Text"];
            string Photodescription = Request.Form["Photodescription"];
            _Backstage.CreateNew(Name, Photo, Date, Title, Introduction, Text, Photodescription);
            var datanews = _Backstage.GetNews();
            return View("Index",datanews);
        }

        public IActionResult Edit(string id)
        {
            var datanew = _Backstage.GetNew(id);
            return View(datanew);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editnew(IFormCollection form)
        {
            string id = Request.Form["Id"];
            string Name = Request.Form["Name"];
            string Photo = Request.Form["Photo"];
            string Date = Request.Form["Date"];
            string Title = Request.Form["Title"];
            string Introduction = Request.Form["Introduction"];
            string Text = Request.Form["Text"];
            string Photodescription = Request.Form["Photodescription"];
            _Backstage.UpdateNew(id,Name, Photo, Date, Title, Introduction, Text, Photodescription);
            return RedirectToAction(nameof(Index)); //回最新消息的首頁
        }

        public IActionResult Details(string id)
        {
            var datanew = _Backstage.GetNew(id);
            return View(datanew);
        }
        public IActionResult Delete(string id)
        {
            _Backstage.DeleteNew(id);
            return RedirectToAction(nameof(Index)); //回最新消息的首頁
        }
    }
}
