//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InPatient
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
    
        public virtual managenurse managenurse { get; set; }
    }
}
