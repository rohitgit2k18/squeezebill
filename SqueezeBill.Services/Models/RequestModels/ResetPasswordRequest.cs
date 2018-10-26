using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.RequestModels
{
   public class ResetPasswordRequest
    {
        public string otp { get; set; }
        public string newPassword { get; set; }
        public string confirmPassword { get; set; }
    }
}
