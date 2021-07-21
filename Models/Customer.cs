using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Customer
    {
        [Key]
        [Display(Name ="訂單編號")]
        [Required]
        public string ID { get; set; }
        [Display(Name = "房型")]
        [Required]
        public string RoomType { get; set; }
        [Display(Name = "房號")]
        [Required]
        public string RoomNumber { get; set; }
        [Display(Name = "房名")]
        [Required]
        public string RoomName { get; set; }
        [Display(Name = "入住日期")]
        [Required]
        public string ArrivalDate { get; set; }
        [Display(Name = "退房日期")]
        [Required]
        public string DepartureDate { get; set; }
        [Display(Name = "入住天數")]
        [Required]
        public int Nights { get; set; }
        [StringLength(20)]
        [Display(Name = "入住者姓名")]
        [Required]

        public string CustomerName { get; set; }
        [Display(Name = "入住者電話")]
        [Required]

        [StringLength(10)]
        public string CustomerPhone { get; set; }
        [Display(Name = "入住者信箱")]
        [Required]

        public string CustomerEmail { get; set; }
        [Display(Name = "入住預計抵達時間")]
        [Required]
        public string EstimatedArrvialTime { get; set; }
    }
}
