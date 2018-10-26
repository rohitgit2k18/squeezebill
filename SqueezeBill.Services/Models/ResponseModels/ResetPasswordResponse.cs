using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ResetPasswordResponse
    {
        public RPasswordResponse response { get; set; }
    }


    public class RPasswordResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }
   
}
