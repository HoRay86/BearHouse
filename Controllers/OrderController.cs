using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;
using project.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    public class OrderController : Controller
    {
        public IBackstage _Backstage;
        public OrderController(IBackstage backstage)
        {
            _Backstage = backstage;
        }
        public IActionResult Index()
        {
            var data=_Backstage.GetOrders();
            return View(data);
        }
        public IActionResult Edit(string id)
        {
            var data = _Backstage.GetOrder(id);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IFormCollection format)
        {
            string id = Request.Form["ID"];
            string FirstName = Request.Form["FirstName"];
            string LastName = Request.Form["LastName"];
            string Email = Request.Form["Email"];
            string Phone = Request.Form["Phone"];
            string PurchaseAmount = Request.Form["PurchaseAmount"];
            string CreditName = Request.Form["CreditName"];
            string CardNumber = Request.Form["CardNumber"];
            string Cvv = Request.Form["Cvv"];
            string Expirydate = Request.Form["Expirydate"];
            string Requests = Request.Form["Requests"];

            _Backstage.UpdateOrderPeople(id, LastName, FirstName, Email, Phone, Requests, CardNumber, CreditName, Cvv, PurchaseAmount, Expirydate);
            var data = _Backstage.GetOrders();
            return View("Index",data);
        }
        public IActionResult Details(string id)
        {
            var data= _Backstage.TotalOrder(id);
            var orders= _Backstage.TotalOrderroom(id);
            List<Order> Orderroom = new List<Order>();
            foreach(var item in orders)
            {
                Orderroom.Add(new Order()
                {
                    RoomName = item.RoomName,
                    RoomNumber = item.RoomNumber,
                    RoomType = item.RoomType,
                    ArrivalDate = item.ArrivalDate,
                    DepartureDate = item.DepartureDate,
                    Nights = item.Nights,
                });
            }
            HttpContext.Session.Set("orderroom",Orderroom);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            string CustomerData = "CustomerData";
            string CustomerRoom = "CustomerRoom";
            string OrderPeople = "OrderPeople";
            _Backstage.DeleteAllOrder(id, CustomerData);
            _Backstage.DeleteAllOrder(id, CustomerRoom);
            _Backstage.DeleteAllOrder(id, OrderPeople);
            var data = _Backstage.GetOrders();
            return View("Index",data);
        }
    }
}
