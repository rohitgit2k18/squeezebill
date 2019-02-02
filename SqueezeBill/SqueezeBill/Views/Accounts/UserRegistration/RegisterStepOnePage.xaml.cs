using Plugin.Connectivity;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        private RetailerList _objRetailerList;
        #endregion
        public RegisterStepOnePage (RetailerList objRetailerList)
		{
			InitializeComponent ();

            _objRetailerList = new RetailerList();
            if (objRetailerList != null)
            {
                _objRetailerList = objRetailerList;

                imgCompanyLogo.Source = objRetailerList.imagePath;
                XFLBLCompanyRate.Text = $"{objRetailerList.rate:0.00}" + "c";
                XFBTN_Duration.Text = objRetailerList.duration + " Months";
            }

            _objUserRegistrationRequest = new UserRegistrationRequest();
            this.BindingContext = _objUserRegistrationRequest;

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
                        _objUserRegistrationRequest.zipCode <= 0 ||
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