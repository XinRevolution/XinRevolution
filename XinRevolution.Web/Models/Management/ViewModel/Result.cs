using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Web.Models.ViewModel.Management
{
    public class Result<T>
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public Result()
        {
            Status = false;
            Message = "尚未執行操作";
            Data = default(T);
        }
    }
}
