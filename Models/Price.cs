using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Price
    {
        [StringLength(10)]
        [Key]
        public string Roomtype { get; set; }

        public int DayPrice { get; set; }
        
        public int WeekendPrice { get; set; }

        public decimal Discount { get; set; }
        public decimal ServiceFee { get; set; }
    }
}
