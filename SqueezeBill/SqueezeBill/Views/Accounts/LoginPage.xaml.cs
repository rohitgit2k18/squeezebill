using Plugin.Connectivity;
using SqueezeBill.Helpers;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using SqueezeBill.Views.Accounts.UserProfile;
using SqueezeBill.Views.Accounts.UserRegistration;
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
	public partial class LoginPage : ContentPage
	{
        #region Variable Declaration
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private bool IsValid { get; set; }
        private LoginRequest _objLoginRequest;
        private LoginResponse _objLoginResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public LoginPage ()
		{
			InitializeComponent ();
           // NavigationPage.SetHasNavigationBar(this, false);
            _objLoginRequest = new LoginRequest();
            this.BindingContext = _objLoginRequest;
            _objLoginResponse = new LoginResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.LoginApiConstant;
        }

       

        private async void XFBtnLogin_Clicked(object sender, EventArgs e)
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
                    if(string.IsNullOrEmpty(_objLoginRequest.email) || 
                        string.IsNullOrEmpty(_objLoginRequest.password))
                    {
                        await DisplayAlert("", "please fill the details first!", "(X)");
                    }
                    else
                    {
                        if (!IsValid)
                        {
                            await DisplayAlert("", "Email is not in valid formate!", "(X)");
                        }
                        else
                        {

                            _objLoginResponse = await _apiService.LoginAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objLoginRequest);
                            var Response = _objLoginResponse;
                            if (Response.statusCode == 200)
                            {
                                await DisplayAlert("", "Login Successful!", "(X)");
                                Settings.TokenCode = Response.token;
                                Settings.IsLoggedIn = true;
                                var otherPage = new UserNavigationPage();
                                var homePage = App.NavigationPage.Navigation.NavigationStack.First();
                                App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
                                await App.NavigationPage.PopToRootAsync(false);
                            }
                            else
                            {
                                await DisplayAlert("", "Sorry, we can not recognize e-mail or password!!!", "(X)");
                            }
                        }
                    }
                }
            }
            catch (Exception ex){ var mag = ex.Message; }
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

        private void XFLblForgotPassword_Tapped(object sender, EventArgs e)
        {
            try
            {
                App.NavigationPage.Navigation.PushAsync(new ForgotPasswordPage());
            }
           catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void XFLblRegisterUser_Tapped(object sender, EventArgs e)
        {
            try
            {
                App.NavigationPage.Navigation.PushAsync(new AddUser());
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}