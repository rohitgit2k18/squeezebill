using SqueezeBill.Helpers;
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
        private HeaderModel _objHeaderModel;

        private RetailerList _objRetailerList;
        #endregion
        public RegisterStepThreePage (UserRegistrationRequest objUserRegistrationRequest, RetailerList objRetailerList)
		{
			InitializeComponent ();
            NavigationPage.SetBackButtonTitle(this, "");
            XFLblTAC.Text = $"T&C";
            _objRetailerList = new RetailerList();
            if (objRetailerList != null)
            {
                _objRetailerList = objRetailerList;

                imgCompanyLogo.Source = objRetailerList.imagePath;
                XFLBLCompanyRate.Text = $"{objRetailerList.rate:0.00}" + "c";
                XFBTN_Duration.Text = objRetailerList.duration + " Months";
                xflblnoAccounttext.Text = "Haven't started electric service at this address yet? Call " + objRetailerList.retailerName +"at "+ objRetailerList .phoneNumber+ " and set up an account for this address. Then enter the 20-digit number to complete your order.";
                          
            }

            _objUserRegistrationRequest = new UserRegistrationRequest();
            _objUserRegistrationRequest = objUserRegistrationRequest;

            this.BindingContext = _objUserRegistrationRequest;

            _objUserRegistrationResponse = new UserRegistrationResponse();

            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.UserSignUpApiConstant;
            _objHeaderModel = new HeaderModel();
        }

        private void XFImgBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
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
                        await DisplayAlert("", "Please provide Account Number!", "(X)");
                    }
                    else
                    {
                        _objHeaderModel.TokenCode = Settings.TokenCode;
                        _objUserRegistrationResponse = await _apiService.UserRegistrationAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objUserRegistrationRequest);
                        var Response = _objUserRegistrationResponse.response;
                        if (Response.statusCode == 200)
                        {
                            Device.BeginInvokeOnMainThread(() => {

                                DisplayAlert("", Response.message, "(X)");
                            });

                            await  App.NavigationPage.Navigation.PushAsync(new CongratulationPage());
                        }
                        else
                        {
                            Device.BeginInvokeOnMainThread(() => {
                               
                                DisplayAlert("", Response.message, "(X)");
                            });
                           
                        }
                    }
                }
                else
                {
                    _objHeaderModel.TokenCode = Settings.TokenCode;
                    _objUserRegistrationResponse = await _apiService.UserRegistrationAsync(new Get_API_Url().CommonBaseApi(_baseUrl), true, _objHeaderModel, _objUserRegistrationRequest);
                    var Response = _objUserRegistrationResponse.response;
                    if (Response.statusCode == 200)
                    {
                        await DisplayAlert("", "Registeration Successful without MedEdAccount!", "(X)");
                        await App.NavigationPage.Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() => {

                            DisplayAlert("", Response.message, "(X)");
                        });
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
          //  Navigation.PushAsync(new ElectricityAndGasListing());
        }

        private void XFBtnYes_Clicked(object sender, EventArgs e)
        {
            XFBtnYes.BackgroundColor = Color.FromHex("#FF9408");
            XFBtnYes.TextColor = Color.White;
            XFBtnNo.BackgroundColor = Color.White;
            XFBtnNo.TextColor = Color.FromHex("#FF9408");
            _objUserRegistrationRequest.isMedEdAccountat = true;
            XFGridAccountInfo.IsVisible = true;
            xfGridmdAccount.IsVisible = true;
            xfgridNoAccount.IsVisible = false;
            xfcentryaccountnum.IsVisible = true;
            xflblaccountinfo.IsVisible = true;
            XFBtnRegisterUser.IsVisible = true;
            xfentryacc.Focus();
        }

        private void XFBtnNo_Clicked(object sender, EventArgs e)
        {
            XFBtnYes.BackgroundColor = Color.White;
            XFBtnYes.TextColor = Color.FromHex("#FF9408");
            XFBtnNo.BackgroundColor = Color.FromHex("#FF9408");
            XFBtnNo.TextColor = Color.White;
            _objUserRegistrationRequest.isMedEdAccountat = false;
            XFGridAccountInfo.IsVisible = true;
            xfGridmdAccount.IsVisible = false;
            xfgridNoAccount.IsVisible = true;
            xfcentryaccountnum.IsVisible = false;
            xflblaccountinfo.IsVisible = false;
            XFBtnRegisterUser.IsVisible = true;
        }
    }
}