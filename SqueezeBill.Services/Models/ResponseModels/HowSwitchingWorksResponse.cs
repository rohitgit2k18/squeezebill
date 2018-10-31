using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public  class HowSwitchingWorksResponse
    {
        public SwitchingWorkResponse response { get; set; }
    }
    public class SwitchingWorkDetail
    {
        public int id { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string imageURL { get; set; }
    }

    public class SwitchingWorkResponse
    {
        public List<Detail> details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}
