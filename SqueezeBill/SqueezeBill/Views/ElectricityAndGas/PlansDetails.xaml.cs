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
        public PlansDetails(RetailerList objRetailerList)
        {
            InitializeComponent();

            _objRetailerList = new RetailerList();
            _objRetailerList = objRetailerList;

            _objElectricityAndGasPlanDetailsResponse = new ElectricityAndGasPlanDetailsResponse();

            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.ElectricityAndGasDetailApiConstant;

            XFLabelPlanTitle.Text = objRetailerList.retailerName;
            imgCompanyLogo.Source = objRetailerList.imagePath;

            GetPlanDetailsbyId();
        }

        public async void GetPlanDetailsbyId()
        {
            try
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    await DisplayAlert("", "No Network Connection", "(X)");
                }
                else
                {
                    _objElectricityAndGasPlanDetailsResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().GetElectricityAndGasDetailApi(_baseUrl, _objRetailerList.planid, _objRetailerList.isResidential), false, new HeaderModel(), _objElectricityAndGasPlanDetailsResponse);
                    EANDGPResponse result = _objElectricityAndGasPlanDetailsResponse.response;
                    if (result.statusCode != 200)
                    {
                        await DisplayAlert("", "No Supplier is Available", "(X)");
                    }
                    else
                    {
                        base.BindingContext = result;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private void XFImgBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void XFImgNotification_Tapped(object sender, EventArgs e)
        {
        }

        private void XFBtnPlansDetails_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new RegisterStepOnePage(_objRetailerList));
        }
    }
}