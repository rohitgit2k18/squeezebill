using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTransport.Models
{
  public static class Domain
    {
        public static string Url
        {
          
            get
            {
                return "http://61.247.235.93:149/";
               // return "http://125.63.101.163:149/";
               
            }
        }

        public static string LoginApiConstant
        {
            get
            {
                return "api/Login/UserLogin";
            }
        }
        public static string ForgotPasswordApiConstant
        {
            get
            {
                return "api/Login/ForgetPassword";
            }
        }
        public static string ResetPasswordApiConstant
        {
            get
            {
                return "api/Login/ResetPassword";
            }
        }
        public static string GetCountryApiConstant
        {
            get
            {
                return "https://restcountries.eu/rest/v2/all";
            }
        }
        public static string UserSignUpApiConstant
        {
            get
            {
                return "api/Registration/UserRegister";
            }
        }
        public static string GetDetailsByZipCode
        {
            get
            {
                return "api/Product/GetZipCodeByCode";
            }
        }
        // for homepage
        public static string LoadDataByZipCodeApiConstant
        {
            get
            {
                return "api/Product/CompareRates";
            }
        }
        
        public static string ElectricityAndGasDetailApiConstant
        {
            get
            {
                return "api/Product/PlanDetails";
            }
        }

        public static string ListofFaqApiConstant
        {
            get
            {
                return "api/WhySwitching/FAQ";
            }
        }
        // News
        public static string NewsApiConstant
        {
            get
            {
                return "api/NewsImageList/GetListOfImageList";
            }
        }
        // how Switching works
        public static string HowSwitchingWorksApiConstant
        {
            get
            {
                return "api/NewsImageList/GetSwitchImageList";
            }
        }
        // Why Switch
        public static string WhySwitchApiConstant
        {
            get
            {
                return "api/WhySwitching/WhySwitchList";
            }
        }
        // Service Area
        public static string ServiceAreaApiConstant
        {
            get
            {
                return "api/NewsImageList/GetAreaList";
            }
        }
        //Energy Glossery
        public static string EnergyGlosseryApiConstant
        {
            get
            {
                return "api/NewsImageList/GetGlossaryList";
            }
        }
        // Contact Us
        public static string ContactUsApiConstant
        {
            get
            {
                return "api/WhySwitching/Contact";
            }
        }
        //User Detail
        public static string  USerDetailsApiConstant
        {
            get
            {
                return "api/Registration/UserRegistrationDetail";
            }
        }
        // Update User Details
        public static string UpdateUserDetailsApiConstant
        {
            get
            {
                return "api/Registration/UpdateUserRegistration";
            }
        }
        // Update Profile Image
        public static string UpdateUserProfileApiConstant
        {
            get
            {
                return "api/Registration/UpdateUserProfilePic";
            }
        }
        public static string AddScheduleExerciseApiConstant
        {
            get
            {
                return "api/ExerciseSchedule/AddScheduleExercise1";
            }
        }
        public static string ScheduleDetailsApiConstant
        {
            get
            {
                return "api/Schedule/ScheduleWorkoutDetails";
            }
        }
        public static string ExerciseScheduleDetailsApiConstant
        {
            get
            {
                return "api/ExerciseSchedule/ScheduleDetailsById";
            }
        }

       
    }
}
