using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "員工編號")]
        public string WID { get; set; }

        [StringLength(3)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "生日")]
        public DateTime Birth { get; set; }

        [StringLength(10)]
        [Display(Name = "電話")]
        public string Phone { get; set; }

        [StringLength(10)]
        [Display(Name = "身分證號")]
        public string ID { get; set; }

        [StringLength(1)]
        [Display(Name = "性別")]
        public string Sex { get; set; }

        [Display(Name = "年齡")]
        public int Age { get; set; }

    }
}
