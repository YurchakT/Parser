using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace WebParser.Models
{
    public class TransferData
    {
        public int Id { get; set; }
        public HttpPostedFileBase Client { get; set; }
        public string Word { get; set; }
        //public WebClient Client { get; set; }
       
    }
}