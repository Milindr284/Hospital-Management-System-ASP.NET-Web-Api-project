using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PrescriptionResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public Prescription Prescription { get; set; }
        public List<Prescription> lstPrescriptions { get; set; }
    }
}