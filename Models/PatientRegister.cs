using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PatientRegister
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PhoneNo { get; set; }
        public string Dob { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Nationality { get; set; }
        public string Password { get; set; }
    }
}