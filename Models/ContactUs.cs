using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class ContactUs
    {
        
        [Display(Name = "留言日期")]
        public string Id { get; set; }
        [StringLength(20)]
        [Display(Name ="顧客姓名")]
        public string Name { get; set; }
        [StringLength(10)]
        [Display(Name = "顧客電話")]
        public string Phone { get; set; }
        [StringLength(30)]
        [Display(Name = "顧客信箱")]
        public string Address { get; set; }
        [StringLength(50)]
        [Display(Name = "顧客留言")]
        public string ContactMessage { get; set; }
    }
}
