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
    public class FeedbackController : ApiController
    {
        EmployeesEntities db = new EmployeesEntities();

        [Route("api/Feedback/AddFeedback")]
        [HttpPost]
        public FeedbackResponse AddFeedback(FeedbackModel feedbackModel)
        {
            FeedbackResponse feedbackResponse = new FeedbackResponse();
            Feedback Feedback = new Feedback();
            Feedback.FeedbackId = feedbackModel.FeedbackId;
            Feedback.patientname = feedbackModel.patientname;
            Feedback.GiveFeedback = feedbackModel.GiveFeedback;

            if (feedbackModel.Type == "Add")
            {

                if (Feedback != null)
                {
                    db.Feedbacks.Add(Feedback);
                    db.SaveChanges();
                    feedbackResponse.ResponseCode = "200";
                    feedbackResponse.ResponseMessage = "Doctor Added";

                }
                else
                {
                    feedbackResponse.ResponseCode = "100";
                    feedbackResponse.ResponseMessage = "Some error occured";

                }

            }
            if (feedbackModel.Type == "Update")
            {

                if (Feedback != null)
                {
                    db.Entry(Feedback).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    feedbackResponse.ResponseCode = "200";
                    feedbackResponse.ResponseMessage = "Doctor Updated";

                }
                else
                {
                    feedbackResponse.ResponseCode = "100";
                    feedbackResponse.ResponseMessage = "Some error occured";

                }

            }
            if (feedbackModel.Type == "Delete")
            {

                if (Feedback != null)
                {
                    db.Entry(Feedback).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    feedbackResponse.ResponseCode = "200";
                    feedbackResponse.ResponseMessage = "Doctor Deleted";

                }
                else
                {
                    feedbackResponse.ResponseCode = "100";
                    feedbackResponse.ResponseMessage = "Some error occured";

                }

            }
            return feedbackResponse;

        }

        [Route("api/Feedback/GetFeedback")]
        [HttpGet]
        public FeedbackResponse GetFeedback()
        {
            FeedbackResponse feedbackResponse = new FeedbackResponse();
            List<Feedback> lstFeedbacks = new List<Feedback>();
            lstFeedbacks = db.Feedbacks.ToList();
            feedbackResponse.ResponseCode = "200";
            feedbackResponse.ResponseMessage = "Data feteched";
            feedbackResponse.lstFeedbacks = lstFeedbacks;

            return feedbackResponse;

        }

        [Route("api/Feedback/Getdoctor")]
        [HttpGet]
        public object Getdoctor()
        {
            return db.Feedbacks.ToList();
        }

        [Route("api/Feedback/FeedbackByFeedbackId")]
        [HttpPost]
        public FeedbackResponse FeedbackByFeedbackId(FeedbackModel feedbackModel)
        {
            FeedbackResponse feedbackResponse = new FeedbackResponse();
            Feedback Feedback = new Feedback();
            if (feedbackModel != null && feedbackModel.FeedbackId > 0)
            {
                Feedback = db.Feedbacks.FirstOrDefault(x => x.FeedbackId == feedbackModel.FeedbackId);
                feedbackResponse.Feedback = Feedback;

            }
            return feedbackResponse;
        }
    }
}
