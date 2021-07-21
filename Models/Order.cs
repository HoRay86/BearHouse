using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Order
    {
        [Key]
        [Display(Name ="訂單編號")]
        public string ID { get; set; }
        [Display(Name = "房型")]
        public string RoomType { get; set; }
        [Display(Name = "房號")]
        public string RoomNumber { get; set; }
        [Display(Name = "房名")]
        public string RoomName { get; set; }
        [Display(Name = "入住日期")]
        public string ArrivalDate { get; set; }
        [Display(Name = "退房日期")]
        public string DepartureDate { get; set; }
        [Display(Name = "入住天數")]
        public int Nights { get; set; }
        [StringLength(20)]
        [Display(Name = "入住者姓名")]

        public string CustomerName { get; set; }
        [Display(Name = "入住者電話")]

        [StringLength(10)]
        public string CustomerPhone { get; set; }
        [Display(Name = "入住者信箱")]

        public string CustomerEmail { get; set; }
        [Display(Name = "入住預計抵達時間")]
        public string EstimatedArrvialTime { get; set; }
        [Display(Name = "訂房者名")]

        public string LastName { get; set; }
        [Display(Name = "訂房者姓")]

        public string FirstName { get; set; }
        [Display(Name = "訂房者信箱")]

        public string Email { get; set; }
        [Display(Name = "訂房者電話")]

        public string Phone { get; set; }
        [Display(Name = "備註")]

        public string Requests { get; set; }
        [StringLength(16)]
        [Display(Name = "信用卡卡號")]

        public string CardNumber { get; set; }
        [Display(Name = "信用卡持有人")]

        public string CreditName { get; set; }
        [Display(Name = "安全碼")]

        public string Cvv { get; set; }
        [Display(Name = "訂單總金額")]

        public int PurchaseAmount { get; set; }
        [Display(Name = "到期日")]

        public string Expirydate { get; set; }
    }
}
