using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class GetDetailsFromZipcodeResponse
    {
        public ZipResponse response { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }
    public class ZipResponse
    {
        public int stateId { get; set; }
        public string stateName { get; set; }
        public int countyId { get; set; }
        public string countyName { get; set; }
        public int cityId { get; set; }
        public string cityName { get; set; }
    }

    
}
