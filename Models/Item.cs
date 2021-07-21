using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Item
    {
        public string RoomName { get; set; }
        public int DayPrice { get; set; }

        public int Quantity { get; set; }
       
        public int RoomType { get; set; }

        public string Photo { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string RoomNumber { get; set; }
        public int Total { get; set; }

        public string Singlebed { get; set; }

        public string ShowerRoom { get; set; }
        public string Doublebed { get; set; }
 
        public string Airconditioning { get; set; }
    }
}
