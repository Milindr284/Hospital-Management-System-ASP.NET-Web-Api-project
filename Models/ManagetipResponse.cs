using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ManagetipResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public managetip managetip { get; set; }
        public List<managetip> lstmanagetips { get; set; }
    }
}