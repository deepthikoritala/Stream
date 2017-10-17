using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stream.Models
{
    public class TestimonyViewModel
    {
        public int ID { get; set; }
        public string filePath { set; get; }
        public string Description { get; set; }
        public string Language{ get; set; }
        public string Title { get; set; }
        public StreamEnums.FileTypes FileType { get; set; }
    }
}