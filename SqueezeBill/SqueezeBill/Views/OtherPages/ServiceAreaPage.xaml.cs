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
	public partial class ServiceAreaPage : ContentPage
	{
        #region Variable Declaration        
        private ServiceAreaResponse _objServiceAreaResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public ServiceAreaPage ()
		{
			InitializeComponent ();
            _objServiceAreaResponse = new ServiceAreaResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.ServiceAreaApiConstant;
            LoadServiceAreaList();

        }
        private async void LoadServiceAreaList()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("Alert", "No Network Connection", "Ok");
                }
                else
                {
                     XFActivityIndicator.IsVisible = true;
                    _objServiceAreaResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objServiceAreaResponse);
                    var result = _objServiceAreaResponse.response;
                    if (result.statusCode == 200)
                    {

                        // await DisplayAlert("Alert", "Sucess", "Ok");
                        this.BindingContext = result;
                        XFActivityIndicator.IsVisible = false;
                    }
                    else
                    {
                        await DisplayAlert("Alert", "No Data is Available", "Ok");
                        XFActivityIndicator.IsVisible = false;
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