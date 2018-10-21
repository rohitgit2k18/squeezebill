using Plugin.Connectivity;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.Accounts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        #region Variable Declaration
        private LoginRequest _objLoginRequest;
        private LoginResponse _objLoginResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public LoginPage ()
		{
			InitializeComponent ();
            _objLoginRequest = new LoginRequest();
            this.BindingContext = _objLoginRequest;
            _objLoginResponse = new LoginResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.LoginApiConstant;
        }

       

        private async void XFBtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("Alert", "No Network Connection!", "ok");
                }
                else
                {

                }
            }
            catch (Exception ex){ var mag = ex.Message; }
        }
    }
}