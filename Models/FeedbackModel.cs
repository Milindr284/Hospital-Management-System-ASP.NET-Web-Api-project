using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class FeedbackModel
    {
        public int FeedbackId { get; set; }
        public string patientname { get; set; }
        public string GiveFeedback { get; set; }
        public string Type { get; set; }
    }
}