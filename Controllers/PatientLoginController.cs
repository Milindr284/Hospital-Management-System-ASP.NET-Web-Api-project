using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [RoutePrefix("api/patient")]
    public class PatientLoginController : ApiController
    {
        EmployeesEntities DB = new EmployeesEntities();
        [Route("PatientLogin")]
        [HttpPost]
        public IHttpActionResult patientLogin(PatientLogin patientlogin)
        {
            var log = DB.patients.Where(x => x.PatientName.Equals(patientlogin.PatientName) && x.Password.Equals(patientlogin.Password)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else

                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails = log });
        }
        [Route("InsertPatient")]
        [HttpPost]
        public object InsertPatient(PatientRegister Reg)
        {
            try
            {

                patient EL = new patient();
                if (EL.PatientId == 0)
                {
                    EL.PatientName = Reg.PatientName;
                    EL.Password = Reg.Password;
                    EL.PhoneNo = Reg.PhoneNo;
                    EL.Dob = Reg.Dob;
                    EL.Age = Reg.Age;
                    EL.Gender = Reg.Gender;
                    EL.Address = Reg.Address;
                    EL.Zipcode = Reg.Zipcode;
                    EL.City = Reg.City;
                    EL.State = Reg.State;
                    EL.Nationality = Reg.Nationality;
                    DB.patients.Add(EL);
                    DB.SaveChanges();
                    return new PatientResponse
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new PatientResponse
            { Status = "Error", Message = "Invalid Data." };
        }
    }
}
