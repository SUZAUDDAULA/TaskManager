using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Web.Models
{
    public class ReturnObject
    {
        public object token { get; set; }
        public string otpCode { get; set; }
        public string message { get; set; }
        public string role { get; set; }
        public object userInfo { get; set; }
        public object employeeData { get; set; }
    }
}
