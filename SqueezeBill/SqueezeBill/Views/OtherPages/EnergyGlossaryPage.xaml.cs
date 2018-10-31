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
	public partial class EnergyGlossaryPage : ContentPage
	{
        #region Variable Declaration        
        private EnergyGlosseryResponse _objEnergyGlosseryResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public EnergyGlossaryPage ()
		{
			InitializeComponent ();
            _objEnergyGlosseryResponse = new EnergyGlosseryResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.EnergyGlosseryApiConstant;
        }
        private async void LoadEnergyGlosseryList()
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
                    _objEnergyGlosseryResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objEnergyGlosseryResponse);
                    var result = _objEnergyGlosseryResponse.response;
                    if (result.statusCode == 200)
                    {

                        // await DisplayAlert("Alert", "Sucess", "Ok");
                        this.BindingContext = result;
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