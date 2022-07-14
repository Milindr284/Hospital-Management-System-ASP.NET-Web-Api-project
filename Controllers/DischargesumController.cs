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
    public class DischargesumController : ApiController
    {
        EmployeesEntities db = new EmployeesEntities();

        [Route("api/Dischargesum/AddDischargesum")]
        [HttpPost]
        public DischargesumResponse AddDischargesum(DischargesumModel dischargesumModel)
        {
            DischargesumResponse dischargesumResponse = new DischargesumResponse();
            Dischargesum Dischargesum = new Dischargesum();
            Dischargesum.DischargeId = dischargesumModel.DischargeId;
            Dischargesum.Patientname = dischargesumModel.Patientname;
            Dischargesum.AdmissionDate = dischargesumModel.AdmissionDate;
            Dischargesum.DischargeDate = dischargesumModel.DischargeDate;
            Dischargesum.Doctorname = dischargesumModel.Doctorname;
            Dischargesum.DischargeDiagnosis = dischargesumModel.DischargeDiagnosis;
            Dischargesum.Complications = dischargesumModel.Complications;
            Dischargesum.ConditionOnDischarge = dischargesumModel.ConditionOnDischarge;
            if (dischargesumModel.Type == "Add")
            {

                if (Dischargesum != null)
                {
                    db.Dischargesums.Add(Dischargesum);
                    db.SaveChanges();
                    dischargesumResponse.ResponseCode = "200";
                    dischargesumResponse.ResponseMessage = "Doctor Added";

                }
                else
                {
                    dischargesumResponse.ResponseCode = "100";
                    dischargesumResponse.ResponseMessage = "Some error occured";

                }

            }
            if (dischargesumModel.Type == "Update")
            {

                if (Dischargesum != null)
                {
                    db.Entry(Dischargesum).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    dischargesumResponse.ResponseCode = "200";
                    dischargesumResponse.ResponseMessage = "Doctor Updated";

                }
                else
                {
                    dischargesumResponse.ResponseCode = "100";
                    dischargesumResponse.ResponseMessage = "Some error occured";

                }

            }
            if (dischargesumModel.Type == "Delete")
            {

                if (Dischargesum != null)
                {
                    db.Entry(Dischargesum).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    dischargesumResponse.ResponseCode = "200";
                    dischargesumResponse.ResponseMessage = "Doctor Deleted";

                }
                else
                {
                    dischargesumResponse.ResponseCode = "100";
                    dischargesumResponse.ResponseMessage = "Some error occured";

                }

            }
            return dischargesumResponse;

        }

        [Route("api/Dischargesum/GetDischargesum")]
        [HttpGet]
        public DischargesumResponse GetDischargesum()
        {
            DischargesumResponse dischargesumResponse = new DischargesumResponse();
            List<Dischargesum> lstDischargesums = new List<Dischargesum>();
            lstDischargesums = db.Dischargesums.ToList();
            dischargesumResponse.ResponseCode = "200";
            dischargesumResponse.ResponseMessage = "Data feteched";
            dischargesumResponse.lstDischargesums = lstDischargesums;

            return dischargesumResponse;

        }

        [Route("api/Dischargesum/Getdischarge")]
        [HttpGet]
        public object Getdischarge()
        {
            return db.Dischargesums.ToList();
        }

        [Route("api/Dischargesum/ManagedischargeByDischargeId")]
        [HttpPost]
        public DischargesumResponse ManagedischargeByDischargeId(DischargesumModel dischargesumModel)
        {
            DischargesumResponse dischargesumResponse = new DischargesumResponse();
            Dischargesum Dischargesum = new Dischargesum();
            if (dischargesumModel != null && dischargesumModel.DischargeId > 0)
            {
                Dischargesum = db.Dischargesums.FirstOrDefault(x => x.DischargeId == dischargesumModel.DischargeId);
                dischargesumResponse.Dischargesum = Dischargesum;

            }
            return dischargesumResponse;
        }
    }
}
