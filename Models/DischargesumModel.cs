using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DischargesumModel
    {
        public int DischargeId { get; set; }
        public string Patientname { get; set; }
        public string AdmissionDate { get; set; }
        public string DischargeDate { get; set; }
        public string Doctorname { get; set; }
        public string DischargeDiagnosis { get; set; }
        public string Complications { get; set; }
        public Nullable<int> InPatientId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public string ConditionOnDischarge { get; set; }
        public string Type { get; set; }

        public virtual managedoctor managedoctor { get; set; }
        public virtual InPatient InPatient { get; set; }
    }
}