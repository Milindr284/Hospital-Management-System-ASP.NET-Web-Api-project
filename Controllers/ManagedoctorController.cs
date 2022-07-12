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
    public class ManagedoctorController : ApiController
    {
        EmployeesEntities db = new EmployeesEntities();

        [Route("api/Managedoctor/Addmanagedoctor")]
        [HttpPost]
        public ManagedocResponse Addmanagedoctor(ManagedocModel managedocModel)
        {
            ManagedocResponse managedocResponse = new ManagedocResponse();
            managedoctor managedoctor = new managedoctor();
            managedoctor.DoctorId = managedocModel.DoctorId;
            managedoctor.DoctorName = managedocModel.DoctorName;
            managedoctor.PhoneNo = managedocModel.PhoneNo;
            managedoctor.Specialization = managedocModel.Specialization;
            managedoctor.Experience = managedocModel.Experience;
            managedoctor.Qualification = managedocModel.Qualification;
            managedoctor.ConsultationFee = managedocModel.ConsultationFee;
            managedoctor.PhoneNum = managedocModel.PhoneNum;
            if (managedocModel.Type == "Add")
            {
               
                if(managedoctor != null)
                {
                    db.managedoctors.Add(managedoctor);
                    db.SaveChanges();
                    managedocResponse.ResponseCode = "200";
                    managedocResponse.ResponseMessage = "Doctor Added";

                }
                else
                {
                    managedocResponse.ResponseCode = "100";
                    managedocResponse.ResponseMessage = "Some error occured";

                }

            }
            if (managedocModel.Type == "Update")
            {

                if (managedoctor != null)
                {
                    db.Entry(managedoctor).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    managedocResponse.ResponseCode = "200";
                    managedocResponse.ResponseMessage = "Doctor Updated";

                }
                else
                {
                    managedocResponse.ResponseCode = "100";
                    managedocResponse.ResponseMessage = "Some error occured";

                }

            }
            if (managedocModel.Type == "Delete")
            {

                if (managedoctor != null)
                {
                    db.Entry(managedoctor).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    managedocResponse.ResponseCode = "200";
                    managedocResponse.ResponseMessage = "Doctor Deleted";

                }
                else
                {
                    managedocResponse.ResponseCode = "100";
                    managedocResponse.ResponseMessage = "Some error occured";

                }

            }
            return managedocResponse;

        }

        [Route("api/Managedoctor/Getmanagedoctor")]
        [HttpGet]
        public  ManagedocResponse Getmanagedoctor()
        {
            ManagedocResponse managedocResponse = new ManagedocResponse();
            List<managedoctor> lstmanagedoctors = new List<managedoctor>();
            lstmanagedoctors = db.managedoctors.ToList();
            managedocResponse.ResponseCode = "200";
            managedocResponse.ResponseMessage = "Data feteched";
            managedocResponse.lstmanagedoctors = lstmanagedoctors;

            return managedocResponse;

        }

        [Route("api/Managedoctor/ManagedoctorByDoctorId")]
        [HttpPost]
        public ManagedocResponse ManagedoctorByDoctorId(ManagedocModel managedocModel)
        {
            ManagedocResponse managedocResponse = new ManagedocResponse();
            managedoctor managedoctor = new managedoctor();
            if(managedocModel != null  && managedocModel.DoctorId > 0)
            {
                managedoctor = db.managedoctors.FirstOrDefault(x => x.DoctorId == managedocModel.DoctorId);
                managedocResponse.managedoctor = managedoctor;

            }
            return managedocResponse;
        }



    }
}
