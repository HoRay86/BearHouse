using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class CustomerData
    {
        public string ID { get; set; }
        [StringLength(20)]
        public string CustomerName { get; set; }

        [StringLength(10)]
        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }
        public string EstimatedArrvialTime { get; set; }

    }
}
