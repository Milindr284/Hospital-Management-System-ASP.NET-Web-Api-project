using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ManagenurResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public managenurse managenurse { get; set; }
        public List<managenurse> lstmanagenurses { get; set; }
    }
}