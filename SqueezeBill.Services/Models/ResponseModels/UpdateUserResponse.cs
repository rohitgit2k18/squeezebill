using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public  class UpdateUserResponse
    {
        public UpdteResponse response { get; set; }
    }
    public class UpdteResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    
}
