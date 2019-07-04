using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.RequestModels
{
  public  class UserRegistrationRequest
    {
        public string firstName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phoneNumber { get; set; }
        public int phoneCountryCode { get; set; }
        public bool termandCondition1 { get; set; }
        public bool termandCondition2 { get; set; }
        public bool termandCondition3 { get; set; }
        public string medEdAccountatthisAddress { get; set; }
        public string lastName { get; set; }
        public int countryCode { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string zipCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public bool isMedEdAccountat { get; set; }
        public string infoAbout { get; set; }
    }
}
