using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XinRevolution.Web.Models.Management
{
    public class OperationResult<T>
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
