using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class CustomerdataController : Controller
    {
        public IBackstage _Backstage;
        public IDataAccess _dataAccess;
        public CustomerdataController(IBackstage backstage,IDataAccess dataAccess)
        {
            _Backstage = backstage;
            _dataAccess = dataAccess;
        }
        public IActionResult Index()
        {
            var data=_Backstage.customerRooms();
            return View(data);
        }
        public IActionResult Details(string id,string roomnumber)
        {
            var data = _Backstage.customerorderroom(id, roomnumber);
            return View(data);
        }
        public IActionResult Edit(string id, string roomnumber)
        {
            var data = _Backstage.customerorderroom(id, roomnumber);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IFormCollection format)
        {
            string id = Request.Form["ID"];
            string RoomType = Request.Form["RoomType"];
            string RoomName = Request.Form["RoomName"];
            string oldroomnumber= Request.Form["oldroomnumber"];
            string RoomNumber = Request.Form["RoomNumber"];
            string CustomerName = Request.Form["CustomerName"];
            string CustomerPhone = Request.Form["CustomerPhone"];
            string CustomerEmail = Request.Form["CustomerEmail"];
            string ArrivalDate = Request.Form["ArrivalDate"];
            string EstimatedArrvialTime = Request.Form["EstimatedArrvialTime"];
            string DepartureDate = Request.Form["DepartureDate"];
            string Nights = Request.Form["Nights"];
            _Backstage.updatecustomerData(id,CustomerName,CustomerPhone,CustomerEmail,EstimatedArrvialTime);
            if (oldroomnumber != RoomNumber)
            {
                var orderRooms = _dataAccess.GetRoomnumber(ArrivalDate, DepartureDate, Convert.ToInt32(RoomType), 2); //找空房號
                if (orderRooms.Count == 0)
                {
                    var data1 = _Backstage.customerorderroom(id, oldroomnumber);
                    ViewBag.errMsg = "房間已經有人預訂";
                    return View(data1);
                }
                else
                {
                    for (int i = 0; i < orderRooms.Count; i++)
                    {
                        if (orderRooms[i].RoomNumber == RoomNumber)//如果空房號=更新的房號  則更新到資料表
                        {
                            _Backstage.updatecustomerRoom(id, RoomNumber, oldroomnumber, RoomType, RoomName, ArrivalDate, DepartureDate, Nights);
                        }
                    }
                }
            }
            else
            {
                _Backstage.updatecustomerRoom(id, RoomNumber, oldroomnumber, RoomType, RoomName, ArrivalDate, DepartureDate, Nights);
            }

            
            
            var data = _Backstage.customerRooms();
            return View("Index", data);//更新成功則返回首頁
        }
        public IActionResult Delete(string id,string roomnumber)
        {
            var data = _Backstage.customerorderroom(id, roomnumber);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deleteroom(string id, string roomnumber)
        {
            _Backstage.deletecustomerRoom(id, roomnumber);
            var data = _Backstage.customerRooms();
            return View("Index", data);
        }
        public IActionResult Create(string id)
        {
            var data=_Backstage.Customer(id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Createroomorder(IFormCollection format)
        {
                string id = Request.Form["ID"];
                string RoomType = Request.Form["RoomType"];
                string RoomName = Request.Form["RoomName"];
                string RoomNumber = Request.Form["RoomNumber"];
                string ArrivalDate = Request.Form["ArrivalDate"];
                string EstimatedArrvialTime = Request.Form["EstimatedArrvialTime"];
                string DepartureDate = Request.Form["DepartureDate"];
                string Nights = Request.Form["Nights"];
                var orderRooms = _dataAccess.GetRoomnumber(ArrivalDate, DepartureDate, Convert.ToInt32(RoomType), 2); //找空房號
                if (orderRooms.Count == 0)
                {
                    var data1 = _Backstage.Customer(id);
                    ViewBag.errMsg = "房間已經有人預訂";
                    return View("Create",data1);
                }
                else
                {
                    for (int i = 0; i < orderRooms.Count; i++)
                    {
                        if (orderRooms[i].RoomNumber == RoomNumber)//如果空房號=更新的房號  則更新到資料表
                        {
                            _Backstage.newCustomerroom(id, RoomType, RoomNumber, RoomName, ArrivalDate, DepartureDate, Nights);
                        }
                    }
                    var data = _Backstage.customerRooms();
                    return View("Index", data);
                }
            
        }
        public IActionResult ContactUs()
        {
            var data=_Backstage.ContactUs();
            return View(data);
        }
        public IActionResult DeleteContact(string id)
        {
            _Backstage.DeleteContactUs(id);
            var data = _Backstage.ContactUs();
            return View("ContactUs",data);
        }
    }
}
