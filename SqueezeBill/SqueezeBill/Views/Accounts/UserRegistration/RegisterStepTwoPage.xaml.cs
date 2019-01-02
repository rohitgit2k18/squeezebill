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

            _objRetailerList = new RetailerList();
            if (objRetailerList != null)
            {
                _objRetailerList = objRetailerList;

                imgCompanyLogo.Source = objRetailerList.imagePath;
                XFLBLCompanyRate.Text = $"{objRetailerList.rate:0.00}" + "c";
                XFBTN_Duration.Text = objRetailerList.duration + " Months";
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
                DisplayAlert("Alert", "please select terms and conditions!", "OK");
            }
            else
            {
                App.NavigationPage.Navigation.PushAsync(new RegisterStepThreePage(_objUserRegistrationRequest, _objRetailerList));
            }
           
        }

        private void XFBTNDisclosure_Click(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new DisclousersPage());
        }
    }
}