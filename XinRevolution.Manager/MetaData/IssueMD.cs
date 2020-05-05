using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Manager.MetaData
{
    public class IssueMD
    {
        [Required(ErrorMessage = "請攜帶資料列鍵值")]
        [HiddenInput]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "請輸入議題名稱")]
        [StringLength(20, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "議題名稱", Prompt = "請輸入議題名稱")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請輸入議題簡介")]
        [StringLength(500, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "議題簡介", Prompt = "請輸入議題簡介")]
        public string Intro { get; set; }
    }
}
