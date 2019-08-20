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
	public partial class WhySwitchPage : ContentPage
	{
        #region Variable Declaration        
        private WhySwitchResponse _objWhySwitchResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public WhySwitchPage ()
		{
			InitializeComponent ();
            _objWhySwitchResponse = new WhySwitchResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.WhySwitchApiConstant;
            LoadWhySwitchList();
        }
        private async void LoadWhySwitchList()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("", "No Network Connection", "(X)");
                }
                else
                {
                     XFActivityIndicator.IsVisible = true;
                    _objWhySwitchResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objWhySwitchResponse);
                    var result = _objWhySwitchResponse.response;
                    if (result.statusCode == 200)
                    {

                        // await DisplayAlert("Alert", "Sucess", "Ok");
                        this.BindingContext = result;
                        XFActivityIndicator.IsVisible = false;
                    }
                    else
                    {
                        await DisplayAlert("", "No Data is Available", "(X)");
                        XFActivityIndicator.IsVisible = false;
                    }


                }

            }
            catch (Exception ex)
            {
                XFActivityIndicator.IsVisible = false;
                var msg = ex.Message;
            }
        }
    }
}