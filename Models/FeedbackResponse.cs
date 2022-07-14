using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FeedbackResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public Feedback Feedback { get; set; }
        public List<Feedback> lstFeedbacks { get; set; }
    }
}