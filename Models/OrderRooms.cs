using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class OrderRooms 
    {
        public int RoomType { get; set; }
        public int DayPrice { get; set; } 
        public int Amount { get; set; }
        public string RoomName { get; set; }
        public int RoomSize { get; set; }
        public string Photo { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string start { get; set; }
        public string end { get; set; }
    }
}
