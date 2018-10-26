using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ElectricityAndGasPlanDetailsResponse
    {
        public EANDGPResponse response { get; set; }
    }
    public class Details
    {
        public string logo { get; set; }
        public string retailerName { get; set; }
        public string per_Kwh { get; set; }
        public double? fees { get; set; }
        public string greenEnergy { get; set; }
        public int duration { get; set; }
        public string offers { get; set; }
    }

    public class EANDGPResponse
    {
        public Details details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}
