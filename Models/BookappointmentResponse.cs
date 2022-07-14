using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookappointmentResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public BookAppointmnet BookAppointmnet { get; set; }
        public List<BookAppointmnet> lstBookAppointmnets { get; set; }

    }
}