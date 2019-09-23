using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Manager.MetaData
{
    public class IssueItemMD
    {
        [Required(ErrorMessage = "請攜帶資料列鍵值")]
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入子議題標題")]
        [StringLength(20, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "子議題標題", Prompt = "請輸入子議題標題")]
        public string Title { get; set; }

        [Required(ErrorMessage = "請輸入發行日期")]
        [DataType(DataType.Date)]
        [Display(Name = "發行日期", Prompt = "請輸入發行日期")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "請輸入子議題內容")]
        [StringLength(500, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "子議題內容", Prompt = "請輸入子議題內容")]
        public string Content { get; set; }

        [Required(ErrorMessage = "請輸入資源連結")]
        [HiddenInput]
        public string ResourceUrl { get; set; }

        [Required(ErrorMessage = "請攜帶資料列外部鍵值")]
        [HiddenInput]
        public int IssueId { get; set; }

        [FileExtensions(Extensions = "jpg,jpeg,png,svg,mp4", ErrorMessage = "請上傳圖片或影片檔案")]
        [DataType(DataType.Upload)]
        [Display(Name = "請選擇檔案")]
        public IFormFile ResourceFile { get; set; }

        [Required(ErrorMessage = "請選擇資源檔案")]
        [Display(Name = "資源檔案", Prompt = "請選擇資源檔案")]
        public string ResourceName { get; set; }
    }
}
