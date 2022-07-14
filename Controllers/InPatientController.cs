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
    public class InPatientController : ApiController
    {
        EmployeesEntities db = new EmployeesEntities();

        [Route("api/InPatient/Addinpatient")]
        [HttpPost]
        public InpatientResponse Addinpatient(InpatientModel inpatientModel)
        {
            InpatientResponse inpatientResponse = new InpatientResponse();
            InPatient InPatient = new InPatient();
            InPatient.InPatientId = inpatientModel.InPatientId;
            InPatient.PatientName = inpatientModel.PatientName;
            InPatient.PhoneNum = inpatientModel.PhoneNum;
            InPatient.DateOfBirth = inpatientModel.DateOfBirth;
            InPatient.Age = inpatientModel.Age;
            InPatient.Gender = inpatientModel.Gender;
            InPatient.InPatientAddress = inpatientModel.InPatientAddress;
            InPatient.City = inpatientModel.City;
            InPatient.State = inpatientModel.State;
            InPatient.Nationality = inpatientModel.Nationality;
            InPatient.AdmissionDate = inpatientModel.AdmissionDate;
            InPatient.DischargeDate = inpatientModel.DischargeDate;
            InPatient.RoomNo = inpatientModel.RoomNo;
            InPatient.NurseId = inpatientModel.NurseId;
            if (inpatientModel.Type == "Add")
            {

                if (InPatient != null)
                {
                    db.InPatients.Add(InPatient);
                    db.SaveChanges();
                    inpatientResponse.ResponseCode = "200";
                    inpatientResponse.ResponseMessage = "Patient Added";

                }
                else
                {
                    inpatientResponse.ResponseCode = "100";
                    inpatientResponse.ResponseMessage = "Some error occured";

                }

            }
            if (inpatientModel.Type == "Update")
            {

                if (InPatient != null)
                {
                    db.Entry(InPatient).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    inpatientResponse.ResponseCode = "200";
                    inpatientResponse.ResponseMessage = "Patient Updated";

                }
                else
                {
                    inpatientResponse.ResponseCode = "100";
                    inpatientResponse.ResponseMessage = "Some error occured";

                }

            }
            if (inpatientModel.Type == "Delete")
            {

                if (InPatient != null)
                {
                    db.Entry(InPatient).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    inpatientResponse.ResponseCode = "200";
                    inpatientResponse.ResponseMessage = "Patient Deleted";

                }
                else
                {
                    inpatientResponse.ResponseCode = "100";
                    inpatientResponse.ResponseMessage = "Some error occured";

                }

            }
            return inpatientResponse;

        }

        [Route("api/InPatient/GetInPatient")]
        [HttpGet]
        public InpatientResponse GetInPatient()
        {
            InpatientResponse inpatientResponse = new InpatientResponse();
            List<InPatient> lstInPatients = new List<InPatient>();
            lstInPatients = db.InPatients.ToList();
            inpatientResponse.ResponseCode = "200";
            inpatientResponse.ResponseMessage = "Data feteched";
            inpatientResponse.lstInPatients = lstInPatients;

            return inpatientResponse;

        }

        [Route("api/InPatient/InPatientByInPatientId")]
        [HttpPost]
        public InpatientResponse InPatientByInPatientId(InpatientModel inpatientModel)
        {
            InpatientResponse inpatientResponse = new InpatientResponse();
            InPatient InPatient = new InPatient();
            if (inpatientModel != null && inpatientModel.InPatientId > 0)
            {
                InPatient = db.InPatients.FirstOrDefault(x => x.InPatientId == inpatientModel.InPatientId);
                inpatientResponse.InPatient = InPatient;

            }
            return inpatientResponse;
        }
    }
}
