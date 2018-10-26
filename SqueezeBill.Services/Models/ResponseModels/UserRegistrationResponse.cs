using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class UserRegistrationResponse
    {
        public RegResponse response { get; set; }
    }

    

    public class RegResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    
}
