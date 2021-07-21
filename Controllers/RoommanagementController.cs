using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Controllers
{   [Authorize(Roles ="SuperAdmin,Admin")]
    
    public class RoommanagementController : Controller
    {
        private readonly RoomContext _context;
        public IBackstage _Backstage;

        public RoommanagementController(RoomContext context, IBackstage backstage)
        {
            _context = context;
            _Backstage = backstage;
        }

        public IActionResult Index()
        {
            var rooms= _Backstage.GetRooms();
            return View(rooms);
        }

        public IActionResult Details(string id)
        {
            var room = _Backstage.GetRoom(id);
            return View(room);
        }

        // GET: Roommanagement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roommanagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Createroom(IFormCollection format)
        {
            string RoomName = Request.Form["RoomName"];
            string Floor = Request.Form["Floor"];
            string RoomNumber = Request.Form["RoomNumber"];
            string RoomType = Request.Form["RoomType"];
            string DayPrice = Request.Form["DayPrice"];
            _Backstage.CreateRoomNumber(RoomName,Floor,RoomNumber,RoomType);
            if (_Backstage.GetRoomPrice(RoomType) == null)
            {
                _Backstage.CreateRoomPrice(RoomType, DayPrice);
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id)
        {
            var room = _Backstage.GetRoom(id);
            return View(room);
        }

        // POST: Roommanagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditRoom(IFormCollection format)
        {
            string RoomName = Request.Form["RoomName"];
            string Floor = Request.Form["Floor"];
            string RoomNumber = Request.Form["RoomNumber"];
            string RoomType = Request.Form["RoomType"];
            string DayPrice = Request.Form["DayPrice"];
            string oldRoomNumber = Request.Form["oldRoomNumber"];
            string oldRoomType = Request.Form["oldRoomType"];
            _Backstage.UpdateRoom(RoomName,Floor,RoomNumber,RoomType,oldRoomNumber);
            _Backstage.UpdatePrice(RoomType, DayPrice, oldRoomType);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteRoomNumber(string id)
        {
            _Backstage.DeleteRoomNumber(id);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult DeleteRoomType(string id)
        {
            _Backstage.DeleteRoom(id);
            _Backstage.DeleteRoomType(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
