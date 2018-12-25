using SqueezeBill.Services.Models.RequestModels;
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
        #endregion
        public RegisterStepTwoPage (UserRegistrationRequest objUserRegistrationRequest)
		{
			InitializeComponent ();
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
                App.NavigationPage.Navigation.PushAsync(new RegisterStepThreePage(_objUserRegistrationRequest));
            }
           
        }
    }
}