using Plugin.Connectivity;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
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
	public partial class ElectricityAndGasListing : ContentPage
	{
        #region Variable Declaration
        private ComapreRatesByZipcodeRequest _objComapreRatesByZipcodeRequest;
         private ComapreRatesByZipcodeResponse _objComapreRatesByZipcodeResponse;
         private RestApi _apiService;
         private string _baseUrl;
        
        #endregion
        public ElectricityAndGasListing(ComapreRatesByZipcodeRequest ObjComapreRatesByZipcodeRequest)
		{
			InitializeComponent ();
            _objComapreRatesByZipcodeRequest = new ComapreRatesByZipcodeRequest();
            _objComapreRatesByZipcodeRequest = ObjComapreRatesByZipcodeRequest;
            _objComapreRatesByZipcodeResponse = new ComapreRatesByZipcodeResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url + Domain.LoadDataByZipCodeApiConstant;
            LoadSupplierAndRetailerList();
        }
        private async void LoadSupplierAndRetailerList()
        {
            try
            {
                if(!CrossConnectivity.Current.IsConnected)
                {
                   await DisplayAlert("Alert", "No Network Connection", "Ok");
                }
                else
                {
                    XFActivityIndicator.IsVisible = true;
                    _objComapreRatesByZipcodeResponse = await _apiService.ListofRetailerPostAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objComapreRatesByZipcodeRequest);
                    var result = _objComapreRatesByZipcodeResponse.response;
                    if (result.statusCode == 200)
                    {
                        if (result.compareListDetails.supplierList.Count > 0)
                        {
                            if (result.compareListDetails.retailerList.Count > 0)
                            {
                                this.BindingContext = result;
                                RateComparisionList.ItemsSource = result.compareListDetails.retailerList;
                                XFActivityIndicator.IsVisible = false;
                            }
                            else
                            {
                                await DisplayAlert("Alert", "No Retailer is Available", "Ok");
                            }
                        }
                        else
                        {
                            await DisplayAlert("Alert", "No Supplier is Available", "Ok");
                        }

                    }
                }
                
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }       

        private void XFBtnLoadPlans_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new ElectricityAndGasPlans(_objComapreRatesByZipcodeResponse));
        }

        private void XFBtnPlanDetail_Clicked(object sender, EventArgs e)
        {
            var Sender = ((Button)sender);
            var Context = Sender.BindingContext;
            var SelectedItems = Context as RetailerList;

            App.NavigationPage.Navigation.PushAsync(new PlansDetails(SelectedItems));
        }

        private void XFImgFilter_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new ListingFilterPage());
        }
    }
}