using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class EnergyGlosseryResponse
    {
        public EGlosseryResponse response { get; set; }
    }
    public class EGlosseryDetail
    {
        public int id { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
    }

    public class EGlosseryResponse
    {
        public List<Detail> details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}
