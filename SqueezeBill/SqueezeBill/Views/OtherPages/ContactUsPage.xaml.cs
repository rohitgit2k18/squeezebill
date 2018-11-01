using Plugin.Connectivity;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.OtherPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactUsPage : ContentPage
	{
        #region Variable Declaration        
        private ContactUsResponse _objContactUsResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public ContactUsPage ()
		{
			InitializeComponent ();
            _objContactUsResponse = new ContactUsResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.ContactUsApiConstant;
            LoadContactUsDetails();

        }
        private async void LoadContactUsDetails()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("Alert", "No Network Connection", "Ok");
                }
                else
                {
                    // XFActivityIndicator.IsVisible = true;
                    _objContactUsResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objContactUsResponse);
                    var result = _objContactUsResponse.response;
                    if (result.statusCode == 200)
                    {

                        // await DisplayAlert("Alert", "Sucess", "Ok");
                        result.details.CompleteAddress += result.details.address + ", " + result.details.state + ", " + result.details.zipcode;
                        this.BindingContext = result.details;
                    }
                    else
                    {
                        await DisplayAlert("Alert", "No Data is Available", "Ok");
                    }


                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}