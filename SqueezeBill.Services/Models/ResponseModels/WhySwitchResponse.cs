using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
  public  class WhySwitchResponse
    {
        public WhySwitchRes response { get; set; }
    }
    public class WhySwitchDetail
    {
        public int id { get; set; }
        public string description { get; set; }
        public string shortDescription { get; set; }
        public string imagePaht { get; set; }
    }

    public class WhySwitchRes
    {
        public List<WhySwitchDetail> details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}
