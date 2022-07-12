using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ManagenurModel
    {
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public string PhoneNo { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Type { get; set; }
    }
}