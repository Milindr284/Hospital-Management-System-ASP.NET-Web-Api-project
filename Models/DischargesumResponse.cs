using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DischargesumResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public Dischargesum Dischargesum { get; set; }
        public List<Dischargesum> lstDischargesums { get; set; }

    }
}