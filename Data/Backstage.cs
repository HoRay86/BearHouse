using Microsoft.Extensions.Configuration;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data
{
    public class Backstage : IBackstage
    {
        public String _connectionStr { get; set; }
        public IConfiguration _configuration { get; }
        
        public Backstage(IConfiguration configuration)
        {

            _configuration = configuration;
            string path = Directory.GetCurrentDirectory();
            _connectionStr = _configuration.GetConnectionString("BookingContext")
                            .Replace("[DataDirectory]", path);

        }
        public List<Customer> customerRooms() //()搜尋空房間 特定房型
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from CustomerRoom,CustomerData where CustomerData.ID=CustomerRoom.ID"; 
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Customer customer = new Customer();
                            customer.ID = sdr["ID"].ToString();
                            customer.RoomName = sdr["RoomName"].ToString();
                            customer.RoomNumber = sdr["RoomNumber"].ToString();
                            customer.RoomType = sdr["RoomType"].ToString();
                            customer.ArrivalDate = sdr["ArrivalDate"].ToString();
                            customer.DepartureDate = sdr["DepartureDate"].ToString();
                            customer.Nights = Convert.ToInt32(sdr["Nights"]);
                            customer.CustomerEmail= sdr["CustomerEmail"].ToString();
                            customer.CustomerName = sdr["CustomerName"].ToString();
                            customer.CustomerPhone = sdr["CustomerPhone"].ToString();
                            customer.EstimatedArrvialTime = sdr["EstimatedArrvialTime"].ToString();
                            customers.Add(customer);
                        }
                    }

                }

            }
            return customers;
        }
        public Customer customerorderroom(string id,string roomnumber) //單筆顧客訂單
        {
            Customer customers = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from CustomerRoom,CustomerData where CustomerData.ID=CustomerRoom.ID and CustomerData.ID= '" + id+"' and CustomerRoom.RoomNumber= '"+roomnumber +"'"; 
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers = new Customer();
                            customers.ID = sdr["ID"].ToString();
                            customers.RoomName = sdr["RoomName"].ToString();
                            customers.RoomNumber = sdr["RoomNumber"].ToString();
                            customers.RoomType = sdr["RoomType"].ToString();
                            customers.ArrivalDate = sdr["ArrivalDate"].ToString();
                            customers.DepartureDate = sdr["DepartureDate"].ToString();
                            customers.Nights = Convert.ToInt32(sdr["Nights"]);
                            customers.CustomerEmail = sdr["CustomerEmail"].ToString();
                            customers.CustomerName = sdr["CustomerName"].ToString();
                            customers.CustomerPhone = sdr["CustomerPhone"].ToString();
                            customers.EstimatedArrvialTime = sdr["EstimatedArrvialTime"].ToString();

                        }
                    }

                }

            }
            return customers;
        }
        public Customer updatecustomerData(string id, string CustomerName,string CustomerPhone, string CustomerEmail, string EstimatedArrvialTime) //更新顧客資料訂單
        {
            Customer customers = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "update CustomerData set CustomerName = N'"+ CustomerName+"', CustomerPhone = '"+ CustomerPhone+"', CustomerEmail = '"+ CustomerEmail+"', EstimatedArrvialTime = '"+ EstimatedArrvialTime + "' where ID='"+id+"'"; 
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers = new Customer();
                        }
                    }

                }

            }
            return customers;
        }
        public Customer updatecustomerRoom(string id,string RoomNumber,string oldroomnumber ,string RoomType,string RoomName, string ArrivalDate, string DepartureDate, string Nights) //更新顧客房間訂單
        {
            Customer customers = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "update CustomerRoom set RoomType= '"+RoomType+ "', RoomNumber= '" + RoomNumber + "', RoomName= N'" + RoomName + "', ArrivalDate = '" + ArrivalDate + "', DepartureDate = '" + DepartureDate + "', Nights = '" + Nights + "' where ID='" + id + "' and RoomNumber='"+ oldroomnumber + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers = new Customer();
                        }
                    }

                }

            }
            return customers;
        }
        public Customer deletecustomerRoom(string id, string RoomNumber) //刪除某顧客房間訂單
        {
            Customer customers = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "Delete From CustomerRoom where ID='"+id+"' and RoomNumber= '"+RoomNumber+"'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers = new Customer();
                        }
                    }

                }

            }
            return customers;
        }
        public List<Order> GetOrders() //()全部訂單
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from OrderPeople";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Order Order = new Order();
                            Order.ID = sdr["ID"].ToString();
                            Order.LastName = sdr["LastName"].ToString();
                            Order.FirstName = sdr["FirstName"].ToString();
                            Order.Email = sdr["Email"].ToString();
                            Order.Phone = sdr["Phone"].ToString();
                            Order.Requests = sdr["Requests"].ToString();
                            Order.CardNumber = sdr["CardNumber"].ToString();
                            Order.CreditName = sdr["CreditName"].ToString();
                            Order.Cvv = sdr["Cvv"].ToString();
                            Order.PurchaseAmount =Convert.ToInt32(sdr["PurchaseAmount"]);
                            Order.Expirydate = sdr["Expirydate"].ToString();
                            orders.Add(Order);
                        }
                    }

                }

            }
            return orders;
        }
        public Order GetOrder(string id) //單筆訂單資料
        {
            Order order = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from OrderPeople where ID= '" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            order = new Order();
                            order.ID = sdr["ID"].ToString();
                            order.FirstName = sdr["FirstName"].ToString();
                            order.LastName = sdr["LastName"].ToString();
                            order.Email = sdr["Email"].ToString();
                            order.Phone = sdr["Phone"].ToString();
                            order.Requests = sdr["Requests"].ToString();
                            order.PurchaseAmount = Convert.ToInt32(sdr["PurchaseAmount"]);
                            order.CreditName = sdr["CreditName"].ToString();
                            order.Cvv = sdr["Cvv"].ToString();
                            order.CardNumber = sdr["CardNumber"].ToString();
                            order.Expirydate = sdr["Expirydate"].ToString();

                        }
                    }

                }

            }
            return order;
        }
        //更新訂單資料
        public Customer UpdateOrderPeople(string id, string LastName, string FirstName, string Email, string Phone, string Requests, string CardNumber, string CreditName, string Cvv, string PurchaseAmount, string Expirydate) 
        {
            Customer customers = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "update OrderPeople set LastName = N'" + LastName + "', FirstName = N'" + FirstName + "'," +
                    " Email = '" + Email + "', Phone = '" + Phone + "', Requests= N'"+ Requests + "'," +
                    " CardNumber= '"+ CardNumber + "',CreditName= N'"+CreditName+"', Cvv= '"+Cvv+"'," +
                    "PurchaseAmount= '"+ PurchaseAmount + "', Expirydate= '"+ Expirydate + "' where ID='" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers = new Customer();
                        }
                    }

                }

            }
            return customers;
        }
        public Order TotalOrder(string id) //單筆訂單的所有資料
        {
            Order order = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from OrderPeople LEFT JOIN CustomerData ON OrderPeople.ID=CustomerData.ID  where OrderPeople.ID = '" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            order = new Order();
                            order.ID = sdr["ID"].ToString();
                            order.FirstName = sdr["FirstName"].ToString();
                            order.LastName = sdr["LastName"].ToString();
                            order.Email = sdr["Email"].ToString();
                            order.Phone = sdr["Phone"].ToString();
                            order.Requests = sdr["Requests"].ToString();
                            order.PurchaseAmount = Convert.ToInt32(sdr["PurchaseAmount"]);
                            order.CreditName = sdr["CreditName"].ToString();
                            order.Cvv = sdr["Cvv"].ToString();
                            order.CardNumber = sdr["CardNumber"].ToString();
                            order.Expirydate = sdr["Expirydate"].ToString();
                            order.CustomerEmail = sdr["CustomerEmail"].ToString();
                            order.CustomerName = sdr["CustomerName"].ToString();
                            order.CustomerPhone = sdr["CustomerPhone"].ToString();
                            order.EstimatedArrvialTime = sdr["EstimatedArrvialTime"].ToString();
                        }
                    }

                }

            }
            return order;
        }
        public List<Order> TotalOrderroom(string id) //單筆訂單的所有訂房資料
        {
            List<Order> order = new List<Order>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from CustomerRoom where ID = '" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Order orders = new Order();
                            orders.ID = sdr["ID"].ToString();
                            orders.RoomType = sdr["RoomType"].ToString();
                            orders.RoomNumber = sdr["RoomNumber"].ToString();
                            orders.RoomName = sdr["RoomName"].ToString();
                            orders.ArrivalDate = sdr["ArrivalDate"].ToString();
                            orders.DepartureDate = sdr["DepartureDate"].ToString();
                            orders.Nights = Convert.ToInt32(sdr["Nights"]);
                            order.Add(orders);
                        }
                    }

                }

            }
            return order;
        }
        public Order DeleteAllOrder(string id,string table) //刪除某資料表的某訂單
        {
            Order room = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "Delete From "+table+" where ID='" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            room = new Order();
                        }
                    }

                }

            }
            return room;
        }
        public Customer Customer(string id) //為了新增顧客房間 去找顧客訂單的資料
        {
            Customer customers = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from CustomerRoom where  CustomerRoom.ID= '" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers = new Customer();
                            customers.ID = sdr["ID"].ToString();
                            customers.ArrivalDate = sdr["ArrivalDate"].ToString();
                            customers.DepartureDate = sdr["DepartureDate"].ToString();
                            customers.Nights = Convert.ToInt32(sdr["Nights"]);
                        }
                    }

                }

            }
            return customers;
        }
        public Customer newCustomerroom(string id , string RoomType ,string RoomNumber, string RoomName, string ArrivalDate, string DepartureDate, string Nights)//為了新增顧客房間
        {
            Customer customers = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into CustomerRoom(ID,RoomType,RoomNumber,RoomName,ArrivalDate,DepartureDate,Nights)" +
                    " values('"+id+"','" + RoomType + "','" + RoomNumber + "',N'" + RoomName + "','" + ArrivalDate + "','" + DepartureDate + "','" + Nights + "')";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers = new Customer();
                        }
                    }

                }

            }
            return customers;
        }
        public List<ContactUs> ContactUs() //查看留言
        {
            List<ContactUs> contacts = new List<ContactUs>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from ContactUs Order by Id";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ContactUs contact = new ContactUs();
                            contact.Id = sdr["Id"].ToString();
                            contact.Name = sdr["Name"].ToString();
                            contact.Address = sdr["Address"].ToString();
                            contact.ContactMessage = sdr["ContactMessage"].ToString();
                            contact.Phone= sdr["Phone"].ToString();
                            contacts.Add(contact);
                        }
                    }

                }

            }
            return contacts;
        }
        public ContactUs DeleteContactUs(string id) //刪除留言
        {
            ContactUs contacts = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "Delete from ContactUs where Id = '"+id+"'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            contacts = new ContactUs();
                            
                        }
                    }

                }

            }
            return contacts;
        }
        public ContactUs CreateContactUs(string Name, string Phone, string Address, string ContactMessage) //新增留言
        {
            ContactUs contacts = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into ContactUs(Name,Phone,Address,ContactMessage)" +
                    " values(N'" + Name + "','" + Phone + "',N'" + Address + "',N'" + ContactMessage + "')";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            contacts = new ContactUs();

                        }
                    }

                }

            }
            return contacts;
        }
        public List<News> GetNews() //查看最新消息
        {
            List<News> news = new List<News>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from News Order by Id Desc";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            News new1 = new News();
                            new1.Id = sdr["Id"].ToString();
                            new1.Name = sdr["Name"].ToString();
                            new1.Photo = sdr["Photo"].ToString();
                            new1.Date = sdr["Date"].ToString();
                            new1.Title = sdr["Title"].ToString();
                            new1.Introduction = sdr["Introduction"].ToString();
                            new1.Text = sdr["Text"].ToString();
                            new1.Photodescription = sdr["Photodescription"].ToString();

                            news.Add(new1);
                        }
                    }

                }

            }
            return news;
        }
        public News CreateNew(string Name, string Phone, string Date, string Title,string Introduction, string Text, string Photodescription) //新增最新消息
        {
            News news =null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into News(Name,Photo,Date,Title,Introduction,Text,Photodescription)" +
                    " values(N'" + Name + "','" + Phone + "','" + Date + "',N'" + Title + "',N'"+ Introduction + "',N'"+ Text + "',N'" + Photodescription + "')";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            news = new News();
                        }
                    }

                }

            }
            return news;
        }
        public News GetNew(string id) //查看單筆最新消息
        {
           News news =null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from News where Id= '"+id+"'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            news = new News();
                            news.Id = sdr["Id"].ToString();
                            news.Name = sdr["Name"].ToString();
                            news.Photo = sdr["Photo"].ToString();
                            news.Date = sdr["Date"].ToString();
                            news.Title = sdr["Title"].ToString();
                            news.Introduction = sdr["Introduction"].ToString();
                            news.Text = sdr["Text"].ToString();
                            news.Photodescription = sdr["Photodescription"].ToString();
                        }
                    }

                }

            }
            return news;
        }
        public News UpdateNew(string id, string Name, string Photo, string Date, string Title, string Introduction, string Text, string Photodescription) //維護更新最新消息
        {
            News news = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                     "update News set Name = N'" + Name + "', Photo = '" + Photo + "'," +
                     " Date = '" + Date + "', Title = N'" + Title + "', Introduction = N'" + Introduction + "'," +
                     " Text = N'" + Text + "', Photodescription = N'" + Photodescription + "' where ID='" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            news = new News();
                        }
                    }

                }

            }
            return news;
        }
        public News DeleteNew(string id) //刪除單筆最新消息
        {
            News news = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "Delete from News where Id = '" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            news = new News();

                        }
                    }

                }

            }
            return news;
        }
        public List<Room> GetRooms() //查看所有房間
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from Room,Price where Room.RoomType=Price.RoomType";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Room room = new Room();
                            room.RoomType = sdr["RoomType"].ToString();
                            room.RoomName = sdr["RoomName"].ToString();
                            room.RoomNumber = sdr["RoomNumber"].ToString();
                            room.Floor = sdr["Floor"].ToString();
                            room.DayPrice = Convert.ToInt32(sdr["DayPrice"]);
                            rooms.Add(room);
                        }
                    }

                }

            }
            return rooms;
        }
        public Room GetRoom(string RoomNumber) //查看單一房間
        {
            Room rooms = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from Room,Price where Room.RoomType=Price.RoomType and Room.RoomNumber='"+RoomNumber+"'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            rooms = new Room();
                            rooms.RoomType = sdr["RoomType"].ToString();
                            rooms.RoomName = sdr["RoomName"].ToString();
                            rooms.RoomNumber = sdr["RoomNumber"].ToString();
                            rooms.Floor = sdr["Floor"].ToString();
                            rooms.DayPrice = Convert.ToInt32(sdr["DayPrice"]);
                        }
                    }

                }

            }
            return rooms;
        }
        public Room GetRoomPrice(string RoomType) //查看單一房型價格
        {
            Room rooms = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from Price where Price.RoomType='" + RoomType + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            rooms = new Room();
                            rooms.RoomType = sdr["RoomType"].ToString();
                            rooms.DayPrice = Convert.ToInt32(sdr["DayPrice"]);
                        }
                    }

                }

            }
            return rooms;
        }
        public Room UpdateRoom(string RoomName, string Floor, string RoomNumber, string RoomType, string oldRommNumber) //維護更新房間資料
        {
            Room room = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "update Room set RoomName = N'" + RoomName + "', Floor = '" + Floor + "', RoomNumber = '" + RoomNumber + "', RoomType = '" + RoomType + "' where Room.RoomNumber='" + oldRommNumber + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            room = new Room();
                        }
                    }

                }

            }
            return room;
        }
        public Room UpdatePrice( string RoomType, string DayPrice, string oldRoomType) //維護更新房間價錢資料
        {
            Room room = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "update Price set RoomType = '" + RoomType + "',DayPrice= '"+ DayPrice + "' where Price.RoomType='" + oldRoomType + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            room = new Room();
                        }
                    }

                }

            }
            return room;
        }
        public Room DeleteRoomNumber(string RoomNumber) //刪除單筆房號
        {
            Room room = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "Delete from Room where RoomNumber = '" + RoomNumber + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            room = new Room();

                        }
                    }

                }

            }
            return room;
        }
        public Room DeleteRoom(string RoomType) //刪除此種房型
        {
            Room room = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "Delete from Room where RoomType = '" + RoomType + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            room = new Room();

                        }
                    }

                }

            }
            return room;
        }
        public Room DeleteRoomType(string RoomType)//刪除單筆房型價錢
        {
         
                Room room = null;

                using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
                {
                    string sqlStr =
                    "Delete from Price where RoomType = '" + RoomType + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                    {
                        sqlconn.Open();
                        using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                room = new Room();

                            }
                        }

                    }

                }
                return room;
            
        } 

        public Room CreateRoomPrice(string RoomType,string DayPrice) //新增單筆房型價錢
        {
            Room room = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into Price(RoomType,DayPrice)" +
                    " values('" + RoomType + "','" + DayPrice +"')";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            room = new Room();

                        }
                    }

                }

            }
            return room;
        }


        public Room CreateRoomNumber(string RoomName, string Floor, string RoomNumber, string RoomType) //新增房號
        {
            Room room = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into Room(RoomName,Floor,RoomNumber,RoomType)" +
                    " values(N'" + RoomName + "','" + Floor + "','" + RoomNumber + "','" + RoomType + "')";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            room = new Room();

                        }
                    }

                }

            }
            return room;
        }

    }
}
