using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ServiceAreaResponse
    {
        public SAreaResponse response { get; set; }
    }
    public class SAreaDetail
    {
        public int id { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
    }

    public class SAreaResponse
    {
        public List<SAreaDetail> details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    
}
