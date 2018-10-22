using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.RequestModels
{
   public class ForgotPasswordRequest
    {
        public string emailId { get; set; }
        public string mobileNum { get; set; }
        public int countryCode { get; set; }
    }
}
