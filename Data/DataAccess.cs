using Dapper;
using Microsoft.Extensions.Configuration;
using project.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace project.Data
{
    public class DataAccess : IDataAccess
    {
        public String _connectionStr { get; set; }
        public IConfiguration _configuration { get; }
        public DataAccess(IConfiguration configuration)
        {

            _configuration = configuration;
            string path = Directory.GetCurrentDirectory();
            _connectionStr = _configuration.GetConnectionString("BookingContext")
                            .Replace("[DataDirectory]", path);

        }
        //將資料庫的帳號密碼抓出來與使用者輸入比對
        public UserLogin UserLogins(string account) 
        {
            UserLogin UserLogins = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr = "select * from UserLogin where Account='" + account + "'"; //sql語法 select * from UserLogin where Account='account'  account為輸入的帳號
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            UserLogins = new UserLogin();
                            UserLogins.Account = sdr["Account"].ToString();
                            UserLogins.Password = sdr["Password"].ToString();
                            UserLogins.Authorize = sdr["Authorize"].ToString();
                            UserLogins.WID = sdr["WID"].ToString();
                        }
                    }

                }

            }
            return UserLogins;
        }
        //()可以放任一名稱變數 抓取Room的介紹
        public RoomIntroduction roomIntroduction(int id) 
        {
            RoomIntroduction roomIntroduction = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from Introduction,Price where Introduction.RoomType=Price.RoomType and Introduction.RoomType='" + id + "'"; //sql語法 select * from UserLogin where Account='account'  account為輸入的帳號
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            roomIntroduction = new RoomIntroduction();
                            roomIntroduction.Description = sdr["Description"].ToString();
                            roomIntroduction.RoomTxt = sdr["RoomTxt"].ToString();
                            roomIntroduction.Photo = sdr["Photo"].ToString();
                            roomIntroduction.Photo1 = sdr["Photo1"].ToString();
                            roomIntroduction.Photo2 = sdr["Photo2"].ToString();
                            roomIntroduction.DayPrice = Convert.ToInt32(sdr["DayPrice"]);
                            roomIntroduction.Refrigerator = sdr["Refrigerator"].ToString();
                            roomIntroduction.TV = sdr["TV"].ToString();
                            roomIntroduction.Bathtub = sdr["Bathtub"].ToString();
                            roomIntroduction.Airconditioning = sdr["Airconditioning"].ToString();
                            roomIntroduction.Tellphone = sdr["Tellphone"].ToString();
                            roomIntroduction.Singlebed = sdr["Singlebed"].ToString();
                            roomIntroduction.Doublebed = sdr["Doublebed"].ToString();
                            roomIntroduction.ShowerRoom = sdr["ShowerRoom"].ToString();
                            roomIntroduction.RoomType = sdr["RoomType"].ToString();
                        }
                    }

                }

            }
            return roomIntroduction;
        }
        //後台Introduction抓房間介紹
        public Introduction Introduction(string RoomType)
        {
            Introduction Introduction = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from Introduction where Introduction.RoomType='" + RoomType + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Introduction = new Introduction();
                            Introduction.RoomType = sdr["RoomType"].ToString();
                            Introduction.Photo = sdr["Photo"].ToString();
                            Introduction.Photo1 = sdr["Photo1"].ToString();
                            Introduction.Photo2 = sdr["Photo2"].ToString();
                            Introduction.TV = sdr["TV"].ToString();
                            Introduction.Bathtub = sdr["Bathtub"].ToString();
                            Introduction.Airconditioning = sdr["Airconditioning"].ToString();
                            Introduction.Singlebed = sdr["Singlebed"].ToString();
                            Introduction.Doublebed = sdr["Doublebed"].ToString();
                            Introduction.Tellphone = sdr["Tellphone"].ToString();
                            Introduction.Refrigerator = sdr["Refrigerator"].ToString();
                            Introduction.ShowerRoom = sdr["ShowerRoom"].ToString();
                            Introduction.Description = sdr["Description"].ToString();
                            Introduction.RoomContent = sdr["RoomContent"].ToString();
                            Introduction.RoomTxt = sdr["RoomTxt"].ToString();
                        }
                    }

                }
            }
            return Introduction;
        }
        public List<OrderRooms> orderoneRoom(string start, string end,string room) //()搜尋空房間 特定房型
        {
            List<OrderRooms> orderRooms = new List<OrderRooms>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "SELECT room.RoomName,room.RoomType,count(Room.RoomNumber)as amount,Introduction.Photo,Introduction.Photo1,Introduction.Photo2,Price.DayPrice,Introduction.RoomSize FROM ROOM " +
                    "LEFT JOIN CustomerRoom ON CustomerRoom.RoomNumber = ROOM.RoomNumber AND " +
                    "NOT((ArrivalDate>= '" + end + "' AND DepartureDate>'" + end + "')OR(ArrivalDate <'" + start + "' AND DepartureDate <='" + start + "'))" +
                    " left join price on Price.Roomtype=Room.RoomType left join Introduction on Room.RoomType = Introduction.RoomType " +
                    "WHERE Nights IS NULL AND room.RoomType= '"+room+ "'" +
                    "group by room.RoomName,room.RoomType,Introduction.Photo,Introduction.Photo1,Introduction.Photo2,Price.DayPrice,Introduction.RoomSize order by room.RoomType"; //sql語法 select * from UserLogin where Account='account'  account為輸入的帳號
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            OrderRooms order = new OrderRooms();
                            order.DayPrice = Convert.ToInt32(sdr["DayPrice"]);
                            order.RoomName = sdr["RoomName"].ToString();
                            order.RoomSize = Convert.ToInt32(sdr["RoomSize"]);
                            order.Photo = sdr["Photo"].ToString();
                            order.Photo1 = sdr["Photo1"].ToString();
                            order.Photo2 = sdr["Photo2"].ToString();
                            order.Amount = Convert.ToInt32(sdr["amount"]);
                            order.RoomType = Convert.ToInt32(sdr["RoomType"]);
                            orderRooms.Add(order);
                        }
                    }

                }

            }
            return orderRooms;
        }
        public List<OrderRooms> orderotherRooms(string start, string end, string room) //()搜尋空房間 除了特定房型 
        {
            List<OrderRooms> orderRooms = new List<OrderRooms>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "SELECT room.RoomName,room.RoomType,count(Room.RoomNumber)as amount,Introduction.Photo,Introduction.Photo1,Introduction.Photo2,Price.DayPrice,Introduction.RoomSize FROM ROOM " +
                    "LEFT JOIN CustomerRoom ON CustomerRoom.RoomNumber = ROOM.RoomNumber AND " +
                    "NOT((ArrivalDate>= '" + end + "' AND DepartureDate>'" + end + "')OR(ArrivalDate <'" + start + "' AND DepartureDate <='" + start + "'))" +
                    " left join price on Price.Roomtype=Room.RoomType left join Introduction on Room.RoomType = Introduction.RoomType " +
                    "WHERE Nights IS NULL AND room.RoomType!= '" + room + "'" +
                    "group by room.RoomName,room.RoomType,Introduction.Photo,Introduction.Photo1,Introduction.Photo2,Price.DayPrice,Introduction.RoomSize order by room.RoomType"; //sql語法 select * from UserLogin where Account='account'  account為輸入的帳號
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            OrderRooms order = new OrderRooms();
                            order.DayPrice = Convert.ToInt32(sdr["DayPrice"]);
                            order.RoomName = sdr["RoomName"].ToString();
                            order.RoomSize = Convert.ToInt32(sdr["RoomSize"]);
                            order.Photo = sdr["Photo"].ToString();
                            order.Photo1 = sdr["Photo1"].ToString();
                            order.Photo2 = sdr["Photo2"].ToString();
                            order.Amount = Convert.ToInt32(sdr["amount"]);
                            order.RoomType = Convert.ToInt32(sdr["RoomType"]);
                            orderRooms.Add(order);
                        }
                    }

                }

            }
            return orderRooms;
        }
        public Item GetItems(string Id) //創造購物車的籃子
        {
            Item item = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr = "SELECT * FROM Price,Room,Introduction where Price.RoomType=Room.RoomType and Price.RoomType=Introduction.RoomType and Price.RoomType= '" + Id + "'";

                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            item = new Item();
                            item.DayPrice = Convert.ToInt32(sdr["DayPrice"]);
                            item.RoomName = sdr["RoomName"].ToString();
                            item.RoomType = Convert.ToInt32(sdr["RoomType"]);
                            item.Photo = sdr["Photo"].ToString();
                            item.Photo1 = sdr["Photo1"].ToString();
                            item.Photo2 = sdr["Photo2"].ToString();
                            item.RoomType = Convert.ToInt32(sdr["RoomType"]);
                            item.Airconditioning = sdr["Airconditioning"].ToString();
                            item.ShowerRoom=sdr["ShowerRoom"].ToString();
                            item.Singlebed= sdr["Singlebed"].ToString();
                            item.Doublebed= sdr["Doublebed"].ToString();

                        }
                    }

                }

            }
            return item;
        }

        public News News(int id) //抓取NEW資料表的單一筆資料
        {
            News news = null;

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from News where News.Id='" + id + "'"; //sql語法 select * from UserLogin where Account='account'  account為輸入的帳號
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            news = new News();
                            news.Date = sdr["Date"].ToString();
                            news.Introduction = sdr["Introduction"].ToString();
                            news.Name = sdr["Name"].ToString();
                            news.Photo = sdr["Photo"].ToString();
                            news.Text = sdr["Text"].ToString();
                            news.Title = sdr["Title"].ToString();
                            news.Photodescription = sdr["Photodescription"].ToString();

                        }
                    }

                }

            }
            return news;
        }
        //抓取NEW資料表的資料 最後3筆資料顯示在首頁的new  最後3筆為最新的消息
        public List<News> GetNews3(int num) 
        {
            List<News> news = new List<News>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select Top " + num + " * from News Order by Id Desc"; //sql語法 select * from UserLogin where Account='account'  account為輸入的帳號
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            News news1 = new News();
                            news1.Date = sdr["Date"].ToString();
                            news1.Name = sdr["Name"].ToString();
                            news1.Photo = sdr["Photo"].ToString();
                            news1.Id = sdr["Id"].ToString();
                            news1.Title = sdr["Title"].ToString();
                            news1.Photodescription = sdr["Photodescription"].ToString();
                            news.Add(news1);
                        }
                    }

                }

            }
            return news;
        }
        //抓取NEW資料表的資料 顯示資料在new頁面
        public List<News> GetNews() 
        {
            List<News> news = new List<News>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from News Order by Id DESC"; //sql語法 select * from UserLogin where Account='account'  account為輸入的帳號
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            News news1 = new News();
                            news1.Date = sdr["Date"].ToString();
                            news1.Name = sdr["Name"].ToString();
                            news1.Photo = sdr["Photo"].ToString();
                            news1.Id = sdr["Id"].ToString();
                            news1.Title = sdr["Title"].ToString();
                            news1.Photodescription = sdr["Photodescription"].ToString();
                            news.Add(news1);
                        }
                    }

                }

            }
            return news;
        }
        //抓取房號 呈現在訂單頁面
        public List<Room> GetRoomnumber(string start, string end, int roomtype, int quantity) 
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select top " + quantity+ " Room.RoomNumber,Room.RoomType from room LEFT JOIN CustomerRoom ON CustomerRoom.RoomNumber = ROOM.RoomNumber AND NOT((ArrivalDate >= '" + end+"' AND DepartureDate >'"+end+"')OR(ArrivalDate <'"+start+"' AND DepartureDate <='"+start+"')) WHERE Nights IS NULL and room.RoomType = '"+roomtype+"'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Room room = new Room();
                            room.RoomNumber = sdr["RoomNumber"].ToString();
                            rooms.Add(room);
                        }
                    }

                }

            }
            return rooms;
        }
        //存入OrderPeople
        public  OrderPeople Addorderpeople(string LastName, string FirstName, string Email, string Phone,string Requests, string CardNumber, string CreditName, string Cvv, int PurchaseAmount,string Expirydate)
        {
            OrderPeople people = null;
            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into OrderPeople(LastName, FirstName, Email, Phone,Requests,CardNumber,CreditName,Cvv,PurchaseAmount,Expirydate)" +
                    " values(N'"+LastName+"',N'"+FirstName+"','"+Email+"','"+Phone+ "',N'" + Requests + "','" + CardNumber + "',N'" + CreditName + "','" + Cvv + "','" + PurchaseAmount + "','"+ Expirydate+"')";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            people = new OrderPeople();                            
                        }
                    }

                }

            }
            return people;
        }
        //存入CustomerRoom  insert中有中文會出現亂碼  中文前+N
        public Customer Addcustomerroom(string FirstName,string RoomType, string RoomNumber,string RoomName, string ArrivalDate, string DepartureDate,string Nights)
        {
            Customer customer = null;
            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into CustomerRoom(ID,RoomType,RoomNumber,RoomName,ArrivalDate,DepartureDate,Nights)" +
                    " values((SELECT TOP 1 ID from OrderPeople  WHERE OrderPeople.FirstName = N'"+FirstName+"' order by ID Desc),'"+RoomType+"','"+RoomNumber+"',N'"+ RoomName + "','"+ArrivalDate+"','"+DepartureDate+"','"+ Nights+"')";

                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customer = new Customer();
                        }
                    }

                }

            }
            return customer;
        }
        //存入CustomerData  insert中有中文會出現亂碼  中文前+N
        public CustomerData AddcustomerData(string FirstName, string CustomerName, string CustomerPhone, string CustomerEmail, string EstimatedArrivalTime)
        {
            CustomerData customerdata = null;
            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "insert into CustomerData(ID,CustomerName,CustomerPhone,CustomerEmail,EstimatedArrvialTime) " +
                    "values((SELECT TOP 1 ID from OrderPeople  WHERE OrderPeople.FirstName = N'" + FirstName + "' order by ID Desc),N'" + CustomerName + "','"+ CustomerPhone + "','"+ CustomerEmail + "','"+ EstimatedArrivalTime + "')";

                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customerdata = new CustomerData();
                        }
                    }

                }

            }
            return customerdata;
        }
        //獲得顧客資料
        public CustomerData GetCustomer(string Name,string phone)
        {
            CustomerData customerdata = null;
            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from CustomerData where CustomerData.CustomerName= N'"+ Name + "' and CustomerData.CustomerPhone= '"+phone+"'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customerdata = new CustomerData();
                            customerdata.ID=sdr["ID"].ToString();
                            customerdata.CustomerPhone = sdr["CustomerPhone"].ToString();
                            customerdata.CustomerName = sdr["CustomerName"].ToString();
                            customerdata.CustomerEmail = sdr["CustomerEmail"].ToString();
                            customerdata.EstimatedArrvialTime = sdr["EstimatedArrvialTime"].ToString();


                        }
                    }

                }

            }
            return customerdata;
        }
        //獲得員工資料???

        public Employee Employee(string WID)
        {
            Employee employee = null;
            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from Employee where Employee.WID= '" + WID + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            employee = new Employee();
                            employee.WID = sdr["WID"].ToString();
                            employee.Name = sdr["Name"].ToString();
                            employee.Birth = Convert.ToDateTime(sdr["Birth"]);
                            employee.Phone = sdr["ID"].ToString();
                            employee.ID = sdr["ID"].ToString();
                            employee.Sex = sdr["Sex"].ToString();
                            employee.Age = Convert.ToInt32(sdr["Age"]);
                        }
                    }
                }

            }
            return employee;
        }
        //抓後台AboutUs資料
        public AboutUs AboutUs(string id)
        {
            AboutUs aboutUs = null;
            using (SqlConnection sqlconn = new SqlConnection(_connectionStr))
            {
                string sqlStr =
                    "select * from Aboutus where Aboutus.id= '" + id + "'";
                using (SqlCommand sqlCommand = new SqlCommand(sqlStr, sqlconn))
                {
                    sqlconn.Open();
                    using (SqlDataReader sdr = sqlCommand.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            aboutUs = new AboutUs();
                            aboutUs.id = sdr["id"].ToString();
                            aboutUs.t1 = sdr["t1"].ToString();
                            aboutUs.t2 = sdr["t2"].ToString();
                            aboutUs.t3 = sdr["t3"].ToString();
                            aboutUs.t4 = sdr["t4"].ToString();
                        }
                    }
                }

            }
            return aboutUs;
        }
    }
}
