using Plugin.Connectivity;
using SqueezeBill.Helpers;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
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

namespace SqueezeBill.Views.Accounts.UserProfile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserProfilePage : ContentPage
	{
        #region Variable Declaration
        const string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        private bool IsValid { get; set; }       
        private UserDetailsResponse _objUserDetailsResponse;
        private UpdateUserResponse _objobjUpdateUserResponse;
        private RestApi _apiService;
        private string _baseUrl;
        private string _baseUrlUpdate;
        private HeaderModel _objHeadermodel;
        #endregion
        public UserProfilePage ()
		{
			InitializeComponent ();
            _objUserDetailsResponse = new UserDetailsResponse();
            _objobjUpdateUserResponse = new UpdateUserResponse();
            _apiService = new RestApi();
            _objHeadermodel = new HeaderModel();
            _baseUrl = Domain.Url + Domain.USerDetailsApiConstant;
            _baseUrlUpdate = Domain.Url + Domain.UpdateUserDetailsApiConstant;
            LoadUserProfileData();
        }
        private async void LoadUserProfileData()
        {
            try
            {
                _objHeadermodel.TokenCode = Settings.TokenCode;
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("", "No Network Connection", "(X)");
                }
                else
                {
                    _objUserDetailsResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeadermodel, _objUserDetailsResponse);
                    var result = _objUserDetailsResponse.response;
                    if (result.statusCode == 200)
                    {
                        this.BindingContext = result.details;
                    }
                    else
                    {
                        await DisplayAlert("", "No Data is Available", "(X)");
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = (Regex.IsMatch(e.NewTextValue, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
            // EntryEmail.TextColor = IsValid ? Color.White : Color.Red;           
        }

        private async void XFBtnUpdateUser_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("", "No Network Connection", "(X)");
                }
                else
                {
                    if (string.IsNullOrEmpty(_objUserDetailsResponse.response.details.email))
                    {
                        await DisplayAlert("", "Email can not be null!", "(X)");
                    }
                    else
                    {
                        if (!IsValid)
                        {
                            await DisplayAlert("", "Email is not in a valid format!", "(X)");
                        }
                        else
                        {
                            _objHeadermodel.TokenCode = Settings.TokenCode;
                            _objobjUpdateUserResponse = await _apiService.UpdateUserPostAsync(new Get_API_Url().CommonBaseApi(_baseUrlUpdate), true, _objHeadermodel, _objUserDetailsResponse);
                            var result = _objobjUpdateUserResponse.response;
                            if (result.statusCode == 200)
                            {
                                await DisplayAlert("", "User Updated Sucessfully!", "(X)");
                            }
                            else
                            {
                                await DisplayAlert("", "No Data is Available", "(X)");
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}