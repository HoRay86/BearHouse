using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data
{
    public interface IBackstage
    {
        public List<Customer> customerRooms();
        public Customer customerorderroom(string id,string roomnumber);
        public Customer updatecustomerData(string id, string CustomerName, string CustomerPhone, string CustomerEmail, string EstimatedArrvialTime); //更新顧客資料訂單
        public Customer updatecustomerRoom(string id, string RoomNumber,string oldroomnumber, string RoomType, string RoomName, string ArrivalDate, string DepartureDate, string Nights); //更新顧客房間訂單
        public Customer deletecustomerRoom(string id, string RoomNumber); //刪除某顧客房間訂單
        public List<Order> GetOrders();
        public Customer UpdateOrderPeople(string id, string LastName, string FirstName, string Email, string Phone, string Requests, string CardNumber, string CreditName, string Cvv, string PurchaseAmount, string Expirydate);
        public Order GetOrder(string id);
        public Order TotalOrder(string id);
        public List<Order> TotalOrderroom(string id); //單筆訂單的所有訂房資料
        public Order DeleteAllOrder(string id, string table); //刪除某資料表的某訂單
        public Customer Customer(string id);
        public Customer newCustomerroom(string id, string RoomType, string RoomNumber, string RoomName, string ArrivalDate, string DepartureDate, string Nights);//為了新增顧客房間
        public List<ContactUs> ContactUs();
        public ContactUs DeleteContactUs(string id); //刪除留言
        public ContactUs CreateContactUs(string Name, string Phone, string Address, string ContactMessage); //新增留言
        public List<News> GetNews(); //查所有最新消息
        public News CreateNew(string Name, string Phone, string Date, string Title, string Introduction ,string Text, string Photodescription); //新增最新消息
        public News GetNew(string id); //查看單筆最新消息
        public News UpdateNew(string id, string Name, string Photo, string Date, string Title, string Introduction, string Text, string Photodescription); //維護更新最新消息
        public News DeleteNew(string id); //刪除單筆最新消息
        public List<Room> GetRooms(); //查看所有房間
        public Room GetRoom(string RoomNumber); //查看單一房間
        public Room GetRoomPrice(string RoomType); //查看單一房型價格

        public Room UpdateRoom(string RoomName, string Floor, string RoomNumber, string RoomType, string oldRommNumber); //維護更新房間資料
        public Room UpdatePrice(string RoomType, string DayPrice, string oldRoomType); //維護更新房間價錢資料
        public Room DeleteRoomNumber(string RoomNumber); //刪除單筆房號

        public Room DeleteRoomType(string RoomType); //刪除單筆房型價錢
        public Room DeleteRoom(string RoomType); //刪除此種房型

        public Room CreateRoomPrice(string RoomType, string DayPrice); //新增房型價錢
        public Room CreateRoomNumber(string RoomName, string Floor, string RoomNumber, string RoomType); //新增房號


    }
}
