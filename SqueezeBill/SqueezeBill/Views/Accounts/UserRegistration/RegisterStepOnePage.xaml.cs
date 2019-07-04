using Plugin.Connectivity;
using SqueezeBill.Helpers;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TargetTransport.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.Accounts.UserRegistration
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterStepOnePage : ContentPage
	{
        #region Variable Declaration
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
          @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private bool IsValid { get; set; }
        private UserRegistrationRequest _objUserRegistrationRequest;
        private GetDetailsFromZipcodeResponse _objGetDetailsFromZipcodeResponse;
        private RetailerList _objRetailerList;
        private string _baseUrl;
        private RestApi _apiService;
        private HeaderModel _objHeaderModel;
        #endregion
        public RegisterStepOnePage (RetailerList objRetailerList)
		{
			InitializeComponent ();
            XFLblTAC.Text = $"T&C";
            _objGetDetailsFromZipcodeResponse = new GetDetailsFromZipcodeResponse();
            _baseUrl = Domain.Url + Domain.GetDetailsByZipCode;
            _objHeaderModel = new HeaderModel();
            _apiService = new RestApi();
            _objRetailerList = new RetailerList();
            if (objRetailerList != null)
            {
                _objRetailerList = objRetailerList;

                imgCompanyLogo.Source = objRetailerList.imagePath;
                XFLBLCompanyRate.Text = $"{objRetailerList.rate:0.00}" + "c";
                XFBTN_Duration.Text = objRetailerList.duration + " Months";
            }

            _objUserRegistrationRequest = new UserRegistrationRequest();
            GetDeatailsFromZipCode();
            

        }
        public async void GetDeatailsFromZipCode()
        {
            ZipcodeUrlRequest zipcodeUrlRequest = new ZipcodeUrlRequest();
            _objHeaderModel.TokenCode = Settings.TokenCode;
            _objGetDetailsFromZipcodeResponse = await _apiService.GetDetailsFromZipcodePostAsync(new Get_API_Url().GetDetailsFromZipCodeApi(_baseUrl,Settings.Zipcode), true, _objHeaderModel, zipcodeUrlRequest);
            var Result = _objGetDetailsFromZipcodeResponse;
            if(Result.statusCode==200)
            {
                _objUserRegistrationRequest.zipCode = Settings.Zipcode;
                _objUserRegistrationRequest.state = Result.response.stateName;
                _objUserRegistrationRequest.city = Result.response.cityName;
                this.BindingContext = _objUserRegistrationRequest;
            }
            else
            {
                await DisplayAlert("Error!", "Please Enter a Valid Zipcode!", "ok");
                this.BindingContext = _objUserRegistrationRequest;
            }
        }
        private void XFImgBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void XFBtnReg1_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                DisplayAlert("Alert", "Network Not Connected!", "OK");
            }
            else
            {
             if(!IsValid)
                {
                    DisplayAlert("Alert", "please enter valid email!", "OK");
                }
                else
                {
                    if(string.IsNullOrEmpty(_objUserRegistrationRequest.firstName) ||
                        string.IsNullOrEmpty(_objUserRegistrationRequest.email) ||
                        string.IsNullOrEmpty(_objUserRegistrationRequest.password) ||
                        string.IsNullOrEmpty(_objUserRegistrationRequest.phoneNumber) ||
                        string.IsNullOrEmpty(_objUserRegistrationRequest.zipCode) ||
                        string.IsNullOrEmpty(_objUserRegistrationRequest.state)||
                        string.IsNullOrEmpty(_objUserRegistrationRequest.city)
                        )
                    {
                        DisplayAlert("Alert", "please fill all the field!", "OK");
                    }
                    else
                    {
                        App.NavigationPage.Navigation.PushAsync(new RegisterStepTwoPage(_objUserRegistrationRequest, _objRetailerList));
                    }
                }
            }
            
        }

       

        private void XFEntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }

       
    }
}