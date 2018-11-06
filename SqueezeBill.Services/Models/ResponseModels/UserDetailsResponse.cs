using SqueezeBill.Services.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqueezeBill.Services.Models.ResponseModels
{
   public  class UserDetailsResponse:BaseResponseModel
    {
        public UserDetailsResponse()
        {
            response = new UserDetailResponse();
        }
        private UserDetailResponse _response;
        public UserDetailResponse response 
        {
            get { return _response; }
            set
            {


                _response =value ; OnPropertyChanged();
               
           }
        }
    }

    public class UserDetails:BaseRequestModel
    {
        //public string firstName { get; set; }
        //public string lastName { get; set; }
        //public string email { get; set; }
        //public int countryCode { get; set; }
        //public string mobileNum { get; set; }
        //public string address1 { get; set; }
        //public string address2 { get; set; }
        //public int zipCode { get; set; }
        //public string state { get; set; }
        //public string city { get; set; }
        //public string infoAbout { get; set; }
        //public string profilePic { get; set; }
        //public bool priceAlert { get; set; }

        public string firstName { get; set; }
        public string password { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int countryCode { get; set; }
        public string mobileNum { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int zipCode { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string infoAbout { get; set; }
        public string profilePic { get; set; }
        public bool priceAlert { get; set; }
    }

    public class UserDetailResponse:BaseResponseModel
    {
        public UserDetailResponse()
        {
            details = new UserDetails();
        }
        private UserDetails _details;
        public UserDetails details
        {
            get { return _details; }
            set
            {
                _details = value;OnPropertyChanged();
            }
        }
        public int statusCode { get; set; }
        public string message { get; set; }
    }

   
}
