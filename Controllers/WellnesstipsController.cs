using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class WellnesstipsController : ApiController
    {
        EmployeesEntities db = new EmployeesEntities();
        [Route("api/Managetip/Addmanagetip")]
        [HttpPost]


        public ManagetipResponse Addmanagetip(ManagetipModel managetipModel)
        {
            ManagetipResponse managetipResponse = new ManagetipResponse();
            managetip managetip = new managetip();
            managetip.PostId = managetipModel.PostId;
            managetip.Title = managetipModel.Title;
            managetip.WellnessTips = managetipModel.WellnessTips;
            managetip.BlogLink = managetipModel.BlogLink;
            managetip.Youtubelink = managetipModel.Youtubelink;
            managetip.Symptoms = managetipModel.Symptoms;
            managetip.Prevention = managetipModel.Prevention;
            if (managetipModel.Type == "Add")
            {

                if (managetip != null)
                {
                    db.managetips.Add(managetip);
                    db.SaveChanges();
                    managetipResponse.ResponseCode = "200";
                    managetipResponse.ResponseMessage = "Wellness tip Added";

                }
                else
                {
                    managetipResponse.ResponseCode = "100";
                    managetipResponse.ResponseMessage = "Some error occured";

                }

            }
            if (managetipModel.Type == "Update")
            {

                if (managetip != null)
                {
                    db.Entry(managetip).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    managetipResponse.ResponseCode = "200";
                    managetipResponse.ResponseMessage = "Wellness Tips Updated";

                }
                else
                {
                    managetipResponse.ResponseCode = "100";
                    managetipResponse.ResponseMessage = "Some error occured";

                }

            }
            if (managetipModel.Type == "Delete")
            {

                if (managetip != null)
                {
                    db.Entry(managetip).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    managetipResponse.ResponseCode = "200";
                    managetipResponse.ResponseMessage = "Nurse Deleted";

                }
                else
                {
                    managetipResponse.ResponseCode = "100";
                    managetipResponse.ResponseMessage = "Some error occured";

                }

            }
            return managetipResponse;

        }

        [Route("api/Managetip/Getmanagetip")]
        [HttpGet]
        public ManagetipResponse Getmanagetip()
        {
            ManagetipResponse managetipResponse = new ManagetipResponse();
            List<managetip> lstmanagetips = new List<managetip>();
            lstmanagetips = db.managetips.ToList();
            managetipResponse.ResponseCode = "200";
            managetipResponse.ResponseMessage = "Data feteched";
            managetipResponse.lstmanagetips = lstmanagetips;

            return managetipResponse;

        }

        [Route("api/Managetip/ManagetipByPostId")]
        [HttpPost]
        public ManagetipResponse ManagetipByPostId(ManagetipModel managetipModel)
        {
            ManagetipResponse managetipResponse = new ManagetipResponse();
            managetip managetip = new managetip();
            if (managetipModel != null && managetipModel.PostId > 0)
            {
                managetip = db.managetips.FirstOrDefault(x => x.PostId == managetipModel.PostId);
                managetipResponse.managetip = managetip;

            }
            return managetipResponse;
        }
    }
}
