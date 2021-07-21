using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class AboutUs
    {
        [StringLength(5)]
        [Key]
        public string id { get; set; }

        [StringLength(50)]
        [Display(Name ="描述")]
        public string t1 { get; set; }

        [StringLength(50)]
        [Display(Name = "大標題")]
        public string t2 { get; set; }

        [StringLength(200)]
        [Display(Name = "小標題")]
        public string t3 { get; set; }

        [StringLength(300)]
        [Display(Name = "關於我們的介紹")]
        public string t4 { get; set; }

    }
}
