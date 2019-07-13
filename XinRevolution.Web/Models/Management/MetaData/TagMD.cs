using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Web.Models.Management.MetaData
{
    public class TagMD
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }

        [Required(ErrorMessage = "請輸入標籤名稱")]
        [Display(Name = "標籤名稱", Prompt = "請輸入標籤名稱")]
        public string TagName { get; set; }

        [Required(ErrorMessage = "請選擇狀態")]
        [Display(Name = "狀態", Prompt = "請選擇狀態")]
        public bool Status { get; set; }

        public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>
        {
            new SelectListItem { Text = "開啟" , Value = "true" },
            new SelectListItem { Text = "關閉" , Value = "false" , Selected = true }
        };
    }
}
