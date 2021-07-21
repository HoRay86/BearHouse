using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project.Models
{
    public class News
    {
        [Display(Name = "消息編號")]
        public string Id { get; set; }
        [Display(Name = "消息名稱")]
        public string Name { get; set; }
        [Display(Name = "圖片")]
        public string Photo { get; set; }
        [Display(Name = "消息時間")]
        public string Date { get; set; }
        [Display(Name = "標題")]
        public string Title { get; set; }
        [Display(Name = "介紹")]
        public string Introduction { get; set; }
        [Display(Name = "內文")]
        public string Text { get; set; }
        [Display(Name = "圖片敘述")]
        public string Photodescription { get; set; }
    }
}
