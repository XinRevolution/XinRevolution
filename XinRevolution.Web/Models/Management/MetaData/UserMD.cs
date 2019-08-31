//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using XinRevolution.Entity.Model;

//namespace XinRevolution.Web.Models.Management.MetaData
//{
//    public class UserMD
//    {
//        [Required]
//        [HiddenInput]
//        public long Id { get; set; }

//        [Required(ErrorMessage = "請輸入帳號")]
//        [Display(Name = "帳號", Prompt = "請輸入帳號")]
//        public string Account { get; set; }

//        [Required(ErrorMessage = "請輸入密碼")]
//        [DataType(DataType.Password)]
//        [Display(Name = "密碼", Prompt = "請輸入密碼")]
//        public string Password { get; set; }

//        [Required(ErrorMessage = "請輸入姓名")]
//        [Display(Name = "姓名", Prompt = "請輸入姓名")]
//        public string Name { get; set; }

//        [Required(ErrorMessage = "請輸入電話")]
//        [DataType(DataType.PhoneNumber)]
//        [Display(Name = "電話", Prompt = "請輸入電話")]
//        public string Phone { get; set; }

//        [Required(ErrorMessage = "請輸入 EMail")]
//        [DataType(DataType.EmailAddress)]
//        [Display(Name = "EMail", Prompt = "請輸入 EMail")]
//        public string EMail { get; set; }

//        [Required(ErrorMessage = "請輸入住址")]
//        [Display(Name = "住址", Prompt = "請輸入住址")]
//        public string Address { get; set; }
//    }
//}
