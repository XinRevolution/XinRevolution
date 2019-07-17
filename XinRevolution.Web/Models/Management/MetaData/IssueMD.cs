using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Web.Models.Management.MetaData
{
    public class IssueMD
    {
        [Required]
        [HiddenInput]
        public long Id { get; set; }

        [Required(ErrorMessage = "請輸入議題名稱")]
        [Display(Name = "議題名稱", Prompt = "請輸入議題名稱")]
        public string IssueName { get; set; }

        [Required(ErrorMessage = "請輸入議題簡介")]
        [Display(Name = "議題簡介", Prompt = "請輸入議題簡介")]
        public string Intro { get; set; }
    }
}
