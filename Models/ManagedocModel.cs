using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ManagedocModel
    {
        
            public int DoctorId { get; set; }
            public string DoctorName { get; set; }
            public int PhoneNo { get; set; }
            public string Specialization { get; set; }
            public int Experience { get; set; }
            public string Qualification { get; set; }
            public int ConsultationFee { get; set; }
            public string Type { get; set; }

            public string PhoneNum { get; set; }
    }
}