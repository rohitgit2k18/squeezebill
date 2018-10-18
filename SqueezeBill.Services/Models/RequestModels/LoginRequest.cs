using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.RequestModels
{
   public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
