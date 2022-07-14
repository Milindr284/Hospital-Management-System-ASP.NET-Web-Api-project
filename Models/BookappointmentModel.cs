using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookappointmentModel
    {
        public int AppointmentId { get; set; }
        public string Patientname { get; set; }
        public string Specialization { get; set; }
        public string ConsultingDoctor { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> DoctorId { get; set; }

        public virtual managedoctor managedoctor { get; set; }
        public virtual patient patient { get; set; }
        public string Type { get; set; }
    }
}