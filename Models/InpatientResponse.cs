using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class InpatientResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public InPatient InPatient { get; set; }
        public List<InPatient> lstInPatients { get; set; }
    }
}