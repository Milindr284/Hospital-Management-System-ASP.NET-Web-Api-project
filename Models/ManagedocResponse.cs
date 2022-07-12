using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ManagedocResponse
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public managedoctor managedoctor { get; set; }
        public List<managedoctor> lstmanagedoctors { get; set; }

    }
}