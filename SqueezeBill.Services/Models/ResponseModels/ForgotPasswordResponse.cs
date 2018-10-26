﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ForgotPasswordResponse
    {
        public FPResponse response { get; set; }
    }
    public class FPResponse
    {
        public string message { get; set; }
        public int statusCode { get; set; }
    }

    
}
