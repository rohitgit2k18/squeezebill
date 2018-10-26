using Plugin.Connectivity;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.ResponseModels;
using SqueezeBill.Views.Accounts.UserRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.ElectricityAndGas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlansDetails : ContentPage
	{
        #region Variable Declaration
        private RetailerList _objRetailerList;
        private ElectricityAndGasPlanDetailsResponse _objElectricityAndGasPlanDetailsResponse;
        private RestApi _apiService;
        private string _baseUrl;
        #endregion
        public PlansDetails (RetailerList objRetailerList)
		{
			InitializeComponent ();
            _objRetailerList = new RetailerList();
            _objRetailerList = objRetailerList;
            _objElectricityAndGasPlanDetailsResponse = new ElectricityAndGasPlanDetailsResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.ElectricityAndGasDetailApiConstant;
            GetPlanDetailsbyId();
        }
        public async void  GetPlanDetailsbyId()
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
                    _objElectricityAndGasPlanDetailsResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().GetElectricityAndGasDetailApi(_baseUrl, _objRetailerList.planid, _objRetailerList.isResidential), false, new HeaderModel(), _objElectricityAndGasPlanDetailsResponse);
                    var result = _objElectricityAndGasPlanDetailsResponse.response;
                    if (result.statusCode == 200)
                    {

                        // await DisplayAlert("Alert", "Sucess", "Ok");
                        this.BindingContext = result;
                    }
                        else
                        {
                            await DisplayAlert("Alert", "No Supplier is Available", "Ok");
                        }

                    
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void XFBtnPlansDetails_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new RegisterStepOnePage());
        }
    }
}