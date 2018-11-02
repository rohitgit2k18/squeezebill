using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using SqueezeBill.Views.ElectricityAndGas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.Accounts.UserRegistration
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterStepThreePage : ContentPage
	{
        #region Variable Declaration        
        private UserRegistrationRequest _objUserRegistrationRequest;
        private UserRegistrationResponse _objUserRegistrationResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public RegisterStepThreePage (UserRegistrationRequest objUserRegistrationRequest)
		{
			InitializeComponent ();
            _objUserRegistrationRequest = new UserRegistrationRequest();
            _objUserRegistrationRequest = objUserRegistrationRequest;
            this.BindingContext = _objUserRegistrationRequest;
            _objUserRegistrationResponse = new UserRegistrationResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.UserSignUpApiConstant;
        }

        private async void XFBtnRegisterUser_Clicked(object sender, EventArgs e)
        {
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            try
            {

                if(_objUserRegistrationRequest.isMedEdAccountat)
                {
                   if(string.IsNullOrEmpty(_objUserRegistrationRequest.medEdAccountatthisAddress))
                    {
                        await DisplayAlert("Alert!", "Please provide Account Number!", "Ok");
                    }
                    else
                    {
                        _objUserRegistrationResponse = await _apiService.UserRegistrationAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objUserRegistrationRequest);
                        var Response = _objUserRegistrationResponse.response;
                        if (Response.statusCode == 200)
                        {
                            await DisplayAlert("Alert!","Registeration Successful!", "Ok");
                          await  App.NavigationPage.Navigation.PushAsync(new LoginPage());
                        }
                        else
                        {
                            await DisplayAlert("Alert!", "Some error occured! ", "Ok");
                        }
                    }
                }
                else
                {

                }
                
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
          //  Navigation.PushAsync(new ElectricityAndGasListing());
        }

        private void XFBtnYes_Clicked(object sender, EventArgs e)
        {
            _objUserRegistrationRequest.isMedEdAccountat = true;
        }

        private void XFBtnNo_Clicked(object sender, EventArgs e)
        {
            _objUserRegistrationRequest.isMedEdAccountat = false;
        }
    }
}