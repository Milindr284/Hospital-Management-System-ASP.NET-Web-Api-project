using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeLoginController : ApiController
    {
        EmployeesEntities DB = new EmployeesEntities();
        [Route("Login")]
        [HttpPost]
        public IHttpActionResult employeeLogin(Login login)
        {
            var log = DB.EmployeeLogins.Where(x => x.EmployeeName.Equals(login.EmployeeName) && x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return Ok(new { status = 401, isSuccess = false, message = "Invalid User", });
            }
            else

                return Ok(new { status = 200, isSuccess = true, message = "User Login successfully", UserDetails = log });
        }
        [Route("InsertEmployee")]
        [HttpPost]
        public object InsertEmployee(Register Reg)
        {
            try
            {

                EmployeeLogin EL = new EmployeeLogin();
                if (EL.Id == 0)
                {
                    EL.EmployeeName = Reg.EmployeeName;
                    EL.Password = Reg.Password;
                    DB.EmployeeLogins.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
        [Route("UpdateEmployee")]
        [HttpPost]
        
        public object UpdateEmployee(Update update)
        {
            EmployeesEntities db = new EmployeesEntities();

            update.Password = update.Password;
            update.EmployeeName = update.EmployeeName;

            Response response = new Response();
            
            EmployeeLogin employeeLogin = new EmployeeLogin();

            db.Entry(employeeLogin).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            response.Status = "200";
            response.Message = "Admin password Updated";

            return new Response
            { Status = "Success", Message = "Record SuccessFully Saved." };
        }
    }
}