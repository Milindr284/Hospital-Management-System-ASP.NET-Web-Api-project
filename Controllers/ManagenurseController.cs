using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebApplication1.Controllers
{
    public class ManagenurseController : ApiController
    {
        EmployeesEntities db = new EmployeesEntities();
        [Route("api/Managenurse/Addmanagenurse")]
        [HttpPost]
     

            public ManagenurResponse Addmanagenurse(ManagenurModel managenurModel)
            {
                ManagenurResponse managenurResponse = new ManagenurResponse();
                managenurse managenurse = new managenurse();
                managenurse.NurseId = managenurModel.NurseId;
                managenurse.NurseName = managenurModel.NurseName;
                managenurse.PhoneNo = managenurModel.PhoneNo;
                managenurse.Specialization = managenurModel.Specialization;
                managenurse.Experience = managenurModel.Experience;
                managenurse.Qualification = managenurModel.Qualification;
                if (managenurModel.Type == "Add")
                {

                    if (managenurse != null)
                    {
                        db.managenurses.Add(managenurse);
                        db.SaveChanges();
                        managenurResponse.ResponseCode = "200";
                        managenurResponse.ResponseMessage = "Nurse Added";

                    }
                    else
                    {
                        managenurResponse.ResponseCode = "100";
                        managenurResponse.ResponseMessage = "Some error occured";

                    }

                }
                if (managenurModel.Type == "Update")
                {

                    if (managenurse != null)
                    {
                        db.Entry(managenurse).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        managenurResponse.ResponseCode = "200";
                        managenurResponse.ResponseMessage = "Nurse Updated";

                    }
                    else
                    {
                        managenurResponse.ResponseCode = "100";
                        managenurResponse.ResponseMessage = "Some error occured";

                    }

                }
                if (managenurModel.Type == "Delete")
                {

                    if (managenurse != null)
                    {
                        db.Entry(managenurse).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        managenurResponse.ResponseCode = "200";
                        managenurResponse.ResponseMessage = "Nurse Deleted";

                    }
                    else
                    {
                        managenurResponse.ResponseCode = "100";
                        managenurResponse.ResponseMessage = "Some error occured";

                    }

                }
                return managenurResponse;

            }

            [Route("api/Managenurse/Getmanagenurse")]
            [HttpGet]
            public ManagenurResponse Getmanagenurse()
            {
                ManagenurResponse managenurResponse = new ManagenurResponse();
                List<managenurse> lstmanagenurses = new List<managenurse>();
                lstmanagenurses = db.managenurses.ToList();
                managenurResponse.ResponseCode = "200";
                managenurResponse.ResponseMessage = "Data feteched";
                managenurResponse.lstmanagenurses = lstmanagenurses;

                return managenurResponse;

            }

            [Route("api/Managenurse/ManagenurseByNurseId")]
            [HttpPost]
            public ManagenurResponse ManagenurseByNurseId(ManagenurModel managenurModel)
            {
                ManagenurResponse managenurResponse = new ManagenurResponse();
                managenurse managenurse = new managenurse();
                if (managenurModel != null && managenurModel.NurseId > 0)
                {
                    managenurse = db.managenurses.FirstOrDefault(x => x.NurseId == managenurModel.NurseId);
                    managenurResponse.managenurse = managenurse;

                }
                return managenurResponse;
            }

        }

}

