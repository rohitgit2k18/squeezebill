using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.RequestModels
{
   public class ComapreRatesByZipcodeRequest
   {
        public ComapreRatesByZipcodeRequest()
        {
            requestSearch = new RequestSearch();
            requestFilterSearch = new RequestFilterSearch();
        }
        public RequestSearch requestSearch { get; set; }
        public RequestFilterSearch requestFilterSearch { get; set; }
   }
    public class RequestSearch
    {
        public bool isResidential { get; set; }
        public bool isCommercial { get; set; }
        public bool isElectricity { get; set; }
        public bool isGas { get; set; }
        public string zipCode { get; set; }
    }

    public class RequestFilterSearch
    {
        public int terms { get; set; }
        public string supplierName { get; set; }
    }  
}
