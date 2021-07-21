using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class Introduction
    {
        [StringLength(10)]
        [Key]
        [Display(Name = "房間類型")]
        public string RoomType { get; set; }
        [Display(Name = "房間照片")]
        public string Photo { get; set; }
        [Display(Name = "房間照片1")]
        public string Photo1 { get; set; }
        [Display(Name = "房間照片2")]
        public string Photo2 { get; set; }
        [Display(Name = "房間人數")]
        public int RoomSize { get; set; }
        [Display(Name = "房間描述")]
        public string Description { get; set; }
        [Display(Name = "單人床")]
        public string Singlebed { get; set; }
        [Display(Name = "雙人床")]
        public string Doublebed { get; set; }
        [Display(Name = "電視")]
        public string TV { get; set; }
        [Display(Name = "空調")]
        public string Airconditioning { get; set; }
        [Display(Name = "浴缸")]
        public string Bathtub { get; set; }
        [Display(Name = "電話")]
        public string Tellphone { get; set; }
        [Display(Name = "冰箱")]
        public string Refrigerator { get; set; }
        [Display(Name = "淋浴間")]
        public string ShowerRoom { get; set; }
        [Display(Name = "房間內容")]
        public string RoomContent { get; set; }
        [Display(Name = "房間簡述")]
        public string RoomTxt { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
