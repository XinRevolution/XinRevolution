using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Manager.MetaData
{
    public class UserMD
    {
        [Required(ErrorMessage = "請攜帶資料列鍵值")]
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(20, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "帳號", Prompt = "請輸入帳號")]
        public string Account { get; set; }

        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(20, ErrorMessage = "資料長度過長，請重新輸入")]
        [DataType(DataType.Password)]
        [Display(Name = "密碼", Prompt = "請輸入密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        [StringLength(20, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "姓名", Prompt = "請輸入姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "請輸入電話")]
        [StringLength(20, ErrorMessage = "資料長度過長，請重新輸入")]
        [Phone(ErrorMessage = "資料格式錯誤，請重新輸入")]
        [Display(Name = "電話", Prompt = "請輸入電話")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "請輸入地址")]
        [StringLength(200, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "地址", Prompt = "請輸入地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "請輸入電郵")]
        [StringLength(200, ErrorMessage = "資料長度過長，請重新輸入")]
        [EmailAddress(ErrorMessage = "資料格式錯誤，請重新輸入")]
        [Display(Name = "電郵", Prompt = "請輸入電郵")]
        public string Mail { get; set; }
    }
}
