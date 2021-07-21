using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class RoomIntroduction
    {
        public string RoomType { get; set; }
        public Introduction Introduction { get; set; }
        public Price price { get; set; }
        public string Photo { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string RoomTxt { get; set; }
        [StringLength(20)]
        public string Description { get; set; }
        public int DayPrice { get; set; }
        public string Singlebed { get; set; }
        public string Doublebed { get; set; }
        public string TV { get; set; }
        public string Airconditioning { get; set; }
        public string Bathtub { get; set; }
        public string Tellphone { get; set; }
        public string Refrigerator { get; set; }
        public string ShowerRoom { get; set; }
    }
}
