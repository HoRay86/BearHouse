using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Room
    {
        [StringLength(10)]
        
        [Display(Name = "房間名稱")]
        public string RoomName { get; set; }

        [StringLength(1)]
        [Display(Name = "樓層")]
        public string Floor { get; set; }
        [Key]
        [StringLength(3)]
        [Display(Name = "房間號碼")]
        public string RoomNumber { get; set; }

        [StringLength(10)]
        [Display(Name = "房間類型")]
        public string RoomType { get; set; }
        [Display(Name = "單價")]

        public int DayPrice { get; set; }
        [Display(Name = "周末價格")]

        public int WeekendPrice { get; set; }
        [Display(Name = "折扣")]

        public decimal Discount { get; set; }
        [Display(Name = "服務費")]
        public decimal ServiceFee { get; set; }


    }
}
