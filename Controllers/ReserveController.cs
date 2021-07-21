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
    
    public class ReserveController : Controller
    {
        public IDataAccess _dataAccess;

        public ReserveController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;

        }
             
        public IActionResult Index()
        {
            string startdate = DateTime.Now.ToString("yyyy/MM/dd");
            string enddate = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
            HttpContext.Session.SetString("start", startdate);
            HttpContext.Session.SetString("end", enddate);
            List<OrderRooms> Orderroom = new List<OrderRooms>();
            string room = "";
            var day = _dataAccess.orderotherRooms(startdate, enddate, room);
            foreach (var item in day)
            {
                Orderroom.Add(new OrderRooms()
                {
                    RoomType = item.RoomType,
                    Photo = item.Photo,
                    Photo1 = item.Photo1,
                    Photo2 = item.Photo2,
                    DayPrice = item.DayPrice,
                    Amount = item.Amount,
                    RoomName = item.RoomName,
                    RoomSize = item.RoomSize,

                });
            }
            if (room != "")
            {
                {
                    string title = "您所選的房型";
                    string title1 = "其他您可以參考的房型";
                    HttpContext.Session.SetString("title", title);
                    HttpContext.Session.SetString("title1", title1);
                }
                HttpContext.Session.SetString("room1", room);
            }
            else
            {
                HttpContext.Session.Remove("title");
                HttpContext.Session.Remove("title1");
            }
            HttpContext.Session.Set("orderroom", Orderroom);
            HttpContext.Session.SetString("room1", room);
            return View();
            
        }

        [HttpPost]
        public IActionResult Find(string startdate, string enddate, string room)
        {//用Session來存搜尋出來的房間  這樣加入購物車後就不用重新搜尋
           
            //HttpContext.Session.SetString("room1", room);
            HttpContext.Session.SetString("start", startdate);
            HttpContext.Session.SetString("end", enddate);
            HttpContext.Session.Get<List<OrderRooms>>("orderroom");
            List<OrderRooms> Orderroom = new List<OrderRooms>();
            if (room != null)
            {
                string title = "您所選的房型";
                string title1 = "其他您可以參考的房型";
                HttpContext.Session.SetString("title", title);
                HttpContext.Session.SetString("title1", title1);
                List<OrderRooms> orders = _dataAccess.orderoneRoom(startdate, enddate, room);
                foreach (var item in orders)
                {
                    Orderroom.Add(new OrderRooms()
                    {
                        RoomType = item.RoomType,
                        Photo = item.Photo,
                        Photo1 = item.Photo1,
                        Photo2 = item.Photo2,
                        DayPrice = item.DayPrice,
                        Amount = item.Amount,
                        RoomName = item.RoomName,
                        RoomSize = item.RoomSize,

                    });
                }
                HttpContext.Session.SetString("room1", room);
            }
            else 
            {
                HttpContext.Session.Remove("title");
                HttpContext.Session.Remove("title1");
            }
            var day = _dataAccess.orderotherRooms(startdate, enddate,room);
            foreach(var item in day)
            {
                Orderroom.Add(new OrderRooms()
                {
                        RoomType =item.RoomType,
                        Photo=item.Photo,
                        Photo1=item.Photo1,
                        Photo2=item.Photo2,
                        DayPrice=item.DayPrice,
                        Amount=item.Amount,
                        RoomName=item.RoomName,
                        RoomSize=item.RoomSize,
                        
                });
            }
            HttpContext.Session.Set("orderroom", Orderroom);
            
            return View("Index");
        }
        [HttpPost]
        public IActionResult Join(string Id ,IFormCollection form)
        {
            int totalprice = 0;
            //新增至購物車
            int Quantity = Convert.ToInt32(Request.Form["Quantity"]);
            if (Quantity > 0)
            {
                if (HttpContext.Session.Get<List<Item>>("Cart") == null)
                {
                    List<Item> cart = new List<Item>();
                    var items = _dataAccess.GetItems(Id);
                    cart.Add(new Item()
                    {
                        RoomName = items.RoomName,
                        DayPrice = items.DayPrice,
                        Quantity = Quantity,
                        RoomType = items.RoomType,
                        Photo = items.Photo,
                        Photo1 = items.Photo1,
                        Photo2 = items.Photo2,
                        Total = items.DayPrice * Quantity

                    });
                    for (int i = 0; i < cart.Count; i++)
                    {
                        totalprice = totalprice + cart[i].Total;
                    }
                    string Totalprice = totalprice.ToString();
                    HttpContext.Session.SetString("Total", Totalprice);
                    HttpContext.Session.Set("Cart", cart);
                }
                else
                {
                    List<Item> cart = HttpContext.Session.Get<List<Item>>("Cart");
                    var items = _dataAccess.GetItems(Id);
                    int id = Convert.ToInt32(Id);
                    int Index = isExist(id);
                    if (Index == -1)
                    {
                        // index=-1表示尚未加入 則新增到購物車
                        cart.Add(new Item
                        {
                            RoomName = items.RoomName,
                            DayPrice = items.DayPrice,
                            Quantity = Quantity,
                            RoomType = items.RoomType,
                            Photo = items.Photo,
                            Photo1 = items.Photo1,
                            Photo2 = items.Photo2,
                            Total = items.DayPrice * Quantity
                        });
                        for (int i = 0; i < cart.Count; i++)
                        {
                            totalprice = totalprice + cart[i].Total;
                        }
                        string Totalprice = totalprice.ToString();
                        HttpContext.Session.SetString("Total", Totalprice);
                        HttpContext.Session.Set("Cart", cart);
                    }
                    else
                    {
                        cart[Index].Quantity = Quantity;
                        cart[Index].Total = items.DayPrice * Quantity;
                        HttpContext.Session.Set("Cart", cart);
                        for (int i = 0; i < cart.Count; i++)
                        {
                            totalprice = totalprice + cart[i].Total;
                        }
                        string Totalprice = totalprice.ToString();
                        HttpContext.Session.SetString("Total", Totalprice);
                        
                    }


                }
                
                return View("Index");
            }
            return View("Index");

        }
        //isExist方法在判斷此 房型 是否已經加入購物車 若以加入回傳 i 未加入回傳-1
        public int isExist(int roomtype)
        {
            List<Item> cart = HttpContext.Session.Get<List<Item>>("Cart");
            for(int i = 0; i < cart.Count; i++)
            {
                if (cart[i].RoomType.Equals(roomtype))
                {
                    return i;
                }
            }
            return -1;
        }
        //刪除購物車內某一房型 以房型做判斷
        public IActionResult Deletecar(int Id) 
        {
            //int id=Convert.ToInt32(Id);
            List<Item> cart = HttpContext.Session.Get<List<Item>>("Cart");
            int index = isExist(Id);
            cart.Remove(cart[index]);
            HttpContext.Session.Set("Cart",cart);
            return View("Index");
        }
        [HttpPost]
        public IActionResult Check(string start,string end, IFormCollection form)
        {
            //List<Item> roomtype = new List<Item>();
            //roomtype.Add(Request.Form["roomtype"]);
            //string Quantity= Request.Form["Quantity"];
            List<Item> cart = HttpContext.Session.Get<List<Item>>("Cart");
            for (int i = 0; i < cart.Count; i++)
            {
                int roomtype = cart[i].RoomType;
                int quantity = cart[i].Quantity;
                string roomnum = "";
                //查看有哪些房號
                var room = _dataAccess.GetRoomnumber(start, end, roomtype, quantity);
                var items = _dataAccess.GetItems(roomtype.ToString());
                cart[i].Airconditioning = items.Airconditioning;
                cart[i].Singlebed = items.Singlebed;
                cart[i].Doublebed = items.Doublebed;
                cart[i].ShowerRoom = items.ShowerRoom;


                for (int k = 0; k < room.Count; k++)
                {
                    if (k == 0)
                    {
                        roomnum = room[k].RoomNumber;
                    }
                    if (k == 1)
                    {
                        roomnum = roomnum+"、"+room[k].RoomNumber;
                    }
                }
                cart[i].RoomNumber=roomnum;
            }           
            HttpContext.Session.Set("Cart", cart);
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(IFormCollection form)
        {
            int PurchaseAmount = 0;
            List<Item> cart = HttpContext.Session.Get<List<Item>>("Cart");
            for (int i = 0; i < cart.Count; i++)
            {
                PurchaseAmount = PurchaseAmount+ cart[i].DayPrice * cart[i].Quantity;
            }
            string LastName = Request.Form["lastName1"];
            string FirstName = Request.Form["firstName1"];
            string Email = Request.Form["email1"];
            string Phone = Request.Form["phone1"];
            string Requests = Request.Form["message"];
            if (Requests == null)
            {
                Requests = "NULL";
            }
            string CardNumber = Request.Form["CardNumber"];
            string CreditName = Request.Form["CreditName"];
            string Cvv = Request.Form["Cvv"];
            string Expirydate= Request.Form["Month"]+"/"+ Request.Form["Year"];

            _dataAccess.Addorderpeople(LastName, FirstName, Email, Phone, Requests, CardNumber, CreditName, Cvv, PurchaseAmount, Expirydate);
            //以上為orderpeople 新增訂單人
            string day =(Convert.ToDateTime(Request.Form["end"]) - Convert.ToDateTime(Request.Form["start"])).Days.ToString();
            for (int i = 0; i < cart.Count; i++)
            {
                var room = _dataAccess.GetRoomnumber(Request.Form["start"],Request.Form["end"],cart[i].RoomType,cart[i].Quantity);
                for (int k=0;k<room.Count;k++)
                {
                   _dataAccess.Addcustomerroom(FirstName,cart[i].RoomType.ToString(),room[k].RoomNumber,cart[i].RoomName, Request.Form["start"], Request.Form["end"],day);

                }
            }
            //以上為CustomerRoom 新增顧客房間
            string name = Request.Form["name"];
            string phone = Request.Form["phone"];
            string email = Request.Form["email"];
            string time = Request.Form["YourTime"];
            _dataAccess.AddcustomerData(FirstName,name,phone,email,time);
            //以上為CustomerData 新增顧客房間
            HttpContext.Session.Set("Cart", cart);
            var customerData=_dataAccess.GetCustomer(name, phone); ;
            return View(customerData);
        }
        public IActionResult tohome() //清空購物車回首頁及搜尋結果
        {
            List<Item> cart = HttpContext.Session.Get<List<Item>>("Cart");
            cart.Clear();
            HttpContext.Session.Set("Cart", cart);
            List<OrderRooms>  rooms=HttpContext.Session.Get<List<OrderRooms>>("orderroom");
            rooms.Clear();
            HttpContext.Session.Set("orderroom", rooms);

            return RedirectToAction("Index", "Home");
        }
    }
}
