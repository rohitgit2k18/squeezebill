using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public class ContactUsResponse
    {
        public ContactResponse response { get; set; }
    }

    public class ContactDetails
    {
        public string content { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string zipcode { get; set; }
        public string phoneNumber { get; set; }
        public string CompleteAddress { get; set; }
    }

    public class ContactResponse
    {
        public ContactDetails details { get; set; }
        public string message { get; set; }
        public int statusCode { get; set; }
    }

   
}
