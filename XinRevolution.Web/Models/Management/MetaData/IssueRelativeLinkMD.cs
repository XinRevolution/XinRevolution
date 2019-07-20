using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Web.Models.Management.MetaData
{
    public class IssueRelativeLinkMD
    {
        [Required]
        [HiddenInput]
        public long IssueId { get; set; }

        [Required]
        [HiddenInput]
        public long Id { get; set; }

        public string ResourceName { get; set; }

        [Required(ErrorMessage = "請輸入相關連結")]
        [Display(Name = "相關連結", Prompt = "請輸入相關連結")]
        public string Url { get; set; }

        [Required(ErrorMessage = "請輸入備註")]
        [Display(Name = "備註", Prompt = "請輸入備註")]
        public string Note { get; set; }

        public string ResourceVirtualPath { get; set; }

        [Required]
        public IFormFile UploadFile { get; set; }
    }
}
