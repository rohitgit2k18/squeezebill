using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class LoginResponse
    {
        public string responseMessage { get; set; }
        public int statusCode { get; set; }
        public string token { get; set; }
        public DateTime expiryDate { get; set; }
    }
}
