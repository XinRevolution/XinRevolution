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

        [Required]
        [HiddenInput]
        public string ResourceName { get; set; }

        [Required(ErrorMessage = "請輸入相關連結")]
        [Display(Name = "相關連結", Prompt = "請輸入相關連結")]
        public string Url { get; set; }

        [Required(ErrorMessage = "請輸入備註")]
        [Display(Name = "備註", Prompt = "請輸入備註")]
        public string Note { get; set; }

        [Required]
        [HiddenInput]
        public string ResourceVirtualPath { get; set; }

        [Display(Name = "選擇檔案", Prompt = "請選擇檔案")]
        public IFormFile UploadFile { get; set; }

        [Required(ErrorMessage = "請上傳檔案")]
        [Display(Name = "檔案", Prompt ="請選擇檔案")]
        public string UploadFileName { get; set; }
    }
}
