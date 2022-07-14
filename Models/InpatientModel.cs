using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class InpatientModel
    {
        public int InPatientId { get; set; }
        public string PatientName { get; set; }
        public string PhoneNum { get; set; }
        public string DateOfBirth { get; set; }
        public Nullable<int> Age { get; set; }
        public string Gender { get; set; }
        public string InPatientAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Nationality { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeDate { get; set; }
        public Nullable<int> RoomNo { get; set; }
        public Nullable<int> NurseId { get; set; }

        public string Type { get; set; }

        public virtual managenurse managenurse { get; set; }
    }
}