using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ManagetipModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string WellnessTips { get; set; }
        public string BlogLink { get; set; }
        public string Youtubelink { get; set; }
        public string Symptoms { get; set; }
        public string Prevention { get; set; }
        public string Type { get; set; }
    }
}