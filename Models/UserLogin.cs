using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class UserLogin
    {
        [Key]
        [Display(Name = "員工編號")]
        public string WID { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage ="Account必須輸入")]
        [Display(Name ="帳號")]
        public string Account { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Password必須輸入")]
        [Display(Name = "密碼")]
        public string Password { get; set; }
        [Display(Name = "身分")]
        public string Authorize { get; set; }
    }
}
