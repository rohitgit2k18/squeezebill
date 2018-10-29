using Plugin.Connectivity;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using SqueezeBill.Views.Accounts.UserProfile;
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
                    if(string.IsNullOrEmpty(_objLoginRequest.email) || 
                        string.IsNullOrEmpty(_objLoginRequest.password))
                    {
                        await DisplayAlert("Alert", "please fill the details first!", "ok");
                    }
                    else
                    {
                        _objLoginResponse = await _apiService.LoginAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objLoginRequest);
                        var Response = _objLoginResponse;
                        if (Response.statusCode == 200)
                        {
                            await DisplayAlert("Alert!", "Login Successful!", "Ok");
                            //var otherPage = new UserNavigationPage();
                            //var homePage = App.NavigationPage.Navigation.NavigationStack.First();
                            //App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
                            //await App.NavigationPage.PopToRootAsync(false);                            
                        }
                        else
                        {
                            await DisplayAlert("Alert!", "Please try again!", "Ok");
                        }
                    }
                }
            }
            catch (Exception ex){ var mag = ex.Message; }
        }

        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            // EntryEmail.TextColor = IsValid ? Color.White : Color.Red;           
        }

    }
}