using Plugin.Connectivity;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using SqueezeBill.Views.Accounts.UserRegistration;
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
	public partial class ResetPasswordPage : ContentPage
	{
        #region Variable declaration        
        private ResetPasswordRequest _objResetPasswordRequest;
        private ResetPasswordResponse _objResetPasswordResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public ResetPasswordPage ()
		{
			InitializeComponent ();
            NavigationPage.SetBackButtonTitle(this, "");
            //NavigationPage.SetHasNavigationBar(this, false);
            _objResetPasswordRequest = new ResetPasswordRequest();
            this.BindingContext = _objResetPasswordRequest;
            _objResetPasswordResponse = new ResetPasswordResponse();
            _apiService = new RestApi();
           
            _baseUrl = Domain.Url + Domain.ResetPasswordApiConstant;
        }

        private async void XFBtnResetPassword_Clicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new RegisterStepOnePage());
            if (IsBusy)
            {
                return;
            }
            IsBusy = true;
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("", "No Network Connection!", "(X)");
                }
                else
                {
                    if (string.IsNullOrEmpty(_objResetPasswordRequest.otp) ||
                        string.IsNullOrEmpty(_objResetPasswordRequest.newPassword) ||
                        string.IsNullOrEmpty(_objResetPasswordRequest.confirmPassword))

                    {
                        await DisplayAlert("", "please fill all field first!", "(X)");
                    }
                    else
                    {
                        if (_objResetPasswordRequest.newPassword!= _objResetPasswordRequest.confirmPassword)
                        {
                            await DisplayAlert("", "Confirm Password did not match!", "(X)");
                        }
                        else
                        {
                            _objResetPasswordResponse = await _apiService.ResetPasswordAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objResetPasswordRequest);
                            var Response = _objResetPasswordResponse.response;
                            if (Response.statusCode == 200)
                            {
                                await DisplayAlert("", " Password Chnaged Successfully!!", "(X)");
                                await App.NavigationPage.Navigation.PushAsync(new LoginPage());
                            }
                            else
                            {
                                await DisplayAlert("", "Please try again!", "(X)");
                            }
                        }

                    }
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
        }
    }
}