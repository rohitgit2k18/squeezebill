using Plugin.Connectivity;
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

namespace SqueezeBill.Views.Accounts
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ForgotPasswordPage : ContentPage
	{
        #region Variable declaration
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private bool IsValid { get; set; }
        private ForgotPasswordRequest _objForgotPasswordRequest;
        private ForgotPasswordResponse _objForgotPasswordResponse;
        private RestApi _apiService;
        private string _baseUrl;
#endregion
        public ForgotPasswordPage ()
		{
			InitializeComponent ();
            // NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetBackButtonTitle(this, "");
            _objForgotPasswordRequest = new ForgotPasswordRequest();
            this.BindingContext = _objForgotPasswordRequest;
            _objForgotPasswordResponse = new ForgotPasswordResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.ForgotPasswordApiConstant;
        }

        private async void XFBtnForgotPassword_Clicked(object sender, EventArgs e)
        {
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
                    if (string.IsNullOrEmpty(_objForgotPasswordRequest.emailId))
                       
                    {
                        await DisplayAlert("", "please fill the email first!", "(X)");
                    }
                    else
                    {
                        if(!IsValid)
                        {
                            await DisplayAlert("", "Invalid Email!", "(X)");
                        }
                        else

                        {
                            _objForgotPasswordRequest.mobileNum = string.Empty;
                            _objForgotPasswordResponse = await _apiService.ForgotPasswordAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objForgotPasswordRequest);
                            var Response = _objForgotPasswordResponse.response;
                            if (Response.statusCode == 200)
                            {
                                await DisplayAlert("", " OTP has been sent to your register emailid !!", "(X)");
                                await App.NavigationPage.Navigation.PushAsync(new ResetPasswordPage());
                            }
                            else
                            {
                                await DisplayAlert("", "Please try again!", "(X)");
                            }
                        }
                        
                    }
                }
                //  
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
        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            // EntryEmail.TextColor = IsValid ? Color.White : Color.Red;           
        }
    }
}