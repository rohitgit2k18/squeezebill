using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SqueezeBill.Helpers;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using TargetTransport.Models;
using Xamarin.Forms;

namespace SqueezeBill.Views.Accounts.UserRegistration
{
    public partial class AddUser : ContentPage
    {
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private bool IsValid { get; set; }
        private UserRegistrationRequest _objUserRegistrationRequest;
        private UserRegistrationResponse _objUserRegistrationResponse;
        private HeaderModel _objHeaderModel;
        private RestApi _apiService;
        private string _baseUrl;
        public AddUser()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            _objUserRegistrationResponse = new UserRegistrationResponse();
            _objUserRegistrationRequest = new UserRegistrationRequest();
            _objHeaderModel = new HeaderModel();
            _apiService = new RestApi();
            _baseUrl= Domain.Url + Domain.UserSignUpApiConstant;
            this.BindingContext = _objUserRegistrationRequest;
        }

        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            // EntryEmail.TextColor = IsValid ? Color.White : Color.Red;           
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

               
                    if (string.IsNullOrEmpty(_objUserRegistrationRequest.email) || string.IsNullOrEmpty(_objUserRegistrationRequest.password) || string.IsNullOrEmpty(_objUserRegistrationRequest.firstName) || string.IsNullOrEmpty(_objUserRegistrationRequest.lastName))
                    {
                        await DisplayAlert("", "Please provide Account details!", "(X)");
                    }
                    else
                    {
                        _objHeaderModel.TokenCode = Settings.TokenCode;
                        _objUserRegistrationResponse = await _apiService.UserRegistrationAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, _objHeaderModel, _objUserRegistrationRequest);
                        var Response = _objUserRegistrationResponse.response;
                        if (Response.statusCode == 200)
                        {
                            Device.BeginInvokeOnMainThread(() => {

                                DisplayAlert("Info!", Response.message, "(X)");
                            });

                            await App.NavigationPage.Navigation.PushAsync(new LoginPage());
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() => {

                                DisplayAlert("Error!", Response.message, "(X)");
                            });

                        }
                    }
               
                

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
            //  Navigation.PushAsync(new ElectricityAndGasListing());
        }

    }
}
