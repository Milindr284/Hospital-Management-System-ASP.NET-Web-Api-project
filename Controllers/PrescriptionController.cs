using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class PrescriptionController : ApiController
    {

        EmployeesEntities db = new EmployeesEntities();

        [Route("api/Prescription/Addprescription")]
        [HttpPost]
        public PrescriptionResponse Addprescription(PrescriptionModel prescriptionModel)
        {
            PrescriptionResponse prescriptionResponse = new PrescriptionResponse();
            Prescription Prescription = new Prescription();
            Prescription.PrescriptionId = prescriptionModel.PrescriptionId;
            Prescription.PrescriptionDate = prescriptionModel.PrescriptionDate;
            Prescription.Drugnamedosage = prescriptionModel.Drugnamedosage;
            Prescription.DrugDuration = prescriptionModel.DrugDuration;
            Prescription.patientname = prescriptionModel.patientname;
            Prescription.doctorname = prescriptionModel.doctorname;
            Prescription.PatientId = prescriptionModel.PatientId;
            Prescription.DoctorId = prescriptionModel.DoctorId;
            Prescription.Column_Age = prescriptionModel.Column_Age;
            if (prescriptionModel.Type == "Add")
            {

                if (Prescription != null)
                {
                    db.Prescriptions.Add(Prescription);
                    db.SaveChanges();
                    prescriptionResponse.ResponseCode = "200";
                    prescriptionResponse.ResponseMessage = "Prescription Added";

                }
                else
                {
                    prescriptionResponse.ResponseCode = "100";
                    prescriptionResponse.ResponseMessage = "Some error occured";

                }

            }
            if (prescriptionModel.Type == "Update")
            {

                if (Prescription != null)
                {
                    db.Entry(Prescription).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    prescriptionResponse.ResponseCode = "200";
                    prescriptionResponse.ResponseMessage = "Patient Updated";

                }
                else
                {
                    prescriptionResponse.ResponseCode = "100";
                    prescriptionResponse.ResponseMessage = "Some error occured";

                }

            }
            if (prescriptionModel.Type == "Delete")
            {

                if (Prescription != null)
                {
                    db.Entry(Prescription).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    prescriptionResponse.ResponseCode = "200";
                    prescriptionResponse.ResponseMessage = "Patient Deleted";

                }
                else
                {
                    prescriptionResponse.ResponseCode = "100";
                    prescriptionResponse.ResponseMessage = "Some error occured";

                }

            }
            return prescriptionResponse;

        }

        [Route("api/Prescription/GetPrescription")]
        [HttpGet]
        public PrescriptionResponse GetPrescription()
        {
            PrescriptionResponse prescriptionResponse = new PrescriptionResponse();
            List<Prescription> lstPrescriptions = new List<Prescription>();
            lstPrescriptions = db.Prescriptions.ToList();
            prescriptionResponse.ResponseCode = "200";
            prescriptionResponse.ResponseMessage = "Data feteched";
            prescriptionResponse.lstPrescriptions = lstPrescriptions;

            return prescriptionResponse;

        }

        [Route("api/Prescription/PrescriptionByInPrescriptionId")]
        [HttpPost]
        public PrescriptionResponse PrescriptionByInPrescriptionId(PrescriptionModel prescriptionModel)
        {
            PrescriptionResponse prescriptionResponse = new PrescriptionResponse();
            Prescription Prescription = new Prescription();
            if (prescriptionModel != null && prescriptionModel.PrescriptionId > 0)
            {
                Prescription = db.Prescriptions.FirstOrDefault(x => x.PrescriptionId == prescriptionModel.PrescriptionId);
                prescriptionResponse.Prescription = Prescription;

            }
            return prescriptionResponse;
        }

    }
}
