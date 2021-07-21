using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data
{
    public interface IDataAccess
    {
        //DataAccess有方法就必須在這重複寫一次  才可以在控制器使用裡呼叫 startup必須先註冊DataAccess
        public UserLogin UserLogins(string account);
        public RoomIntroduction roomIntroduction(int id);
        public List<OrderRooms> orderoneRoom(string start, string end, string room);
        public List<OrderRooms> orderotherRooms(string start, string end, string room);

        public Item GetItems(string Id);
        public News News(int id);
        public Introduction Introduction(string RoomType);
        public List<News> GetNews3(int num);
        public List<News> GetNews();
        public List<Room> GetRoomnumber(string start, string end, int roomtype, int quantity);
        public OrderPeople Addorderpeople(string LastName, string FirstName, string Email, string Phone, string Requests, string CardNumber, string CreditName, string Cvv, int PurchaseAmount, string Expirydate);
        public Customer Addcustomerroom(string FirstName, string RoomType, string RoomNumber,string RoomName, string ArrivalDate, string DepartureDate,string Nights);
        public CustomerData AddcustomerData(string FirstName, string CustomerName, string CustomerPhone, string CustomerEmail, string EstimatedArrivalTime);
        public CustomerData GetCustomer(string Name, string phone);
        public Employee Employee(string WID);

        public AboutUs AboutUs(string id);
    }
}
