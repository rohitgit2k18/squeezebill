using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.Accounts.UserRegistration
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterStepTwoPage : ContentPage
	{
        #region Variable Declaration        
        private UserRegistrationRequest _objUserRegistrationRequest;

        private RetailerList _objRetailerList;
        #endregion
        public RegisterStepTwoPage (UserRegistrationRequest objUserRegistrationRequest, RetailerList objRetailerList)
		{
			InitializeComponent ();
            NavigationPage.SetBackButtonTitle(this, "");
            XFLblTAC.Text = $"T&C";
            _objRetailerList = new RetailerList();
            if (objRetailerList != null)
            {
                _objRetailerList = objRetailerList;

                imgCompanyLogo.Source = objRetailerList.imagePath;
                XFLBLCompanyRate.Text = $"{objRetailerList.rate:0.00}" + "c";
                XFBTN_Duration.Text = objRetailerList.duration + " Months";

                TCfirst.Text = "I agree that I have read and understood the Terms and Conditions " +
                    "of" + _objRetailerList.retailerName + "and I hereby agree to be bound by them. " +
                    "I am authorized to make this change for my household, and the account ";

                TCsecond.Text = " allow " + _objRetailerList.retailerName + " and its contractors or affiliates to " +
                    "contact me at the phone number I provided in this enrollment. " +
                    "Contacts by " + _objRetailerList.retailerName + " may be made using automatic" +
                    " dialers, text messaging, or prerecorded messages." +
                    " I understand that I am responsible for any charges" +
                    " by my cellular phone carrier that may result from such " +
                    "contacts. I understand that I can revoke this consent at any time.";

                TCThird.Text = " verify that all information is correct, and " +
                    "that I have authorization to change this account. I understand that " +
                    "electronic acceptance of the sales agreement and " +
                    "Terms or Service is an agreement to initiate service and begin enrollment.";
            }

            _objUserRegistrationRequest = new UserRegistrationRequest();
            _objUserRegistrationRequest = objUserRegistrationRequest;

            this.BindingContext = _objUserRegistrationRequest;
        }

        private void XFImgBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }
        private void XFButtonTAndC_Clicked(object sender, EventArgs e)
        {
            if(!_objUserRegistrationRequest.termandCondition1 ||
                !_objUserRegistrationRequest.termandCondition2 ||
                !_objUserRegistrationRequest.termandCondition3)
            {
                DisplayAlert("", "please select terms and conditions!", "(X)");
            }
            else
            {
                App.NavigationPage.Navigation.PushAsync(new RegisterStepThreePage(_objUserRegistrationRequest, _objRetailerList));
            }
           
        }

        private  void XFBTNDisclosure_Click(object sender, EventArgs e)
        {
            // App.NavigationPage.Navigation.PushAsync(new DisclousersPage());
            OpenURlAsync();
        }
        public async Task OpenURlAsync()
        {
            await Task.Run(() => { Device.OpenUri(new Uri("http://125.63.101.163:150/Content/ConstellationTerms109491.pdf")); });
        }

        
    }
}