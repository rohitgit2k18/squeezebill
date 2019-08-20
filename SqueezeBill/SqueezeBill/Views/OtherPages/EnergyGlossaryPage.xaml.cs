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
            LoadEnergyGlosseryList();
        }
        private async void LoadEnergyGlosseryList()
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
                    _objEnergyGlosseryResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objEnergyGlosseryResponse);
                    var result = _objEnergyGlosseryResponse.response;
                    if (result.statusCode == 200)
                    {
                        XFActivityIndicator.IsVisible = false;
                        // await DisplayAlert("Alert", "Sucess", "Ok");
                        this.BindingContext = result;
                    }
                    else
                    {
                        XFActivityIndicator.IsVisible = false;
                        await DisplayAlert("", "No Data is Available", "(X)");
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