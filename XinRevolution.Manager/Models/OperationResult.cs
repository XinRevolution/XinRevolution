using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Manager.Models
{
    public class OperationResult
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public OperationResult()
        {
            Status = false;
            Message = $"尚未執行操作";
        }
    }

    public class OperationResult<T>
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public OperationResult()
        {

            Status = false;
            Message = $"尚未執行操作";
            Data = default(T);
        }
    }
}
