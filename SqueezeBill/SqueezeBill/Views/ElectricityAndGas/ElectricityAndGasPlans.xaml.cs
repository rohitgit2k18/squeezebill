using SqueezeBill.Services.Models.ResponseModels;
using SqueezeBill.Views.Accounts.UserRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.ElectricityAndGas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ElectricityAndGasPlans : ContentPage
	{
        #region Variable Declaration
        private ComapreRatesByZipcodeResponse _objComapreRatesByZipcodeResponse;
        #endregion
        public ElectricityAndGasPlans(ComapreRatesByZipcodeResponse objComapreRatesByZipcodeResponse)
        {
            InitializeComponent();
            _objComapreRatesByZipcodeResponse = new ComapreRatesByZipcodeResponse();
            _objComapreRatesByZipcodeResponse = objComapreRatesByZipcodeResponse;
            LoadListData();
        }

        private void LoadListData()
        {
            try
            {
                XFActivityIndicator.IsVisible = true;
                if (_objComapreRatesByZipcodeResponse.response.statusCode == 200)
                {
                    if (_objComapreRatesByZipcodeResponse.response.compareListDetails.supplierList.Count > 0)
                    {
                        if (_objComapreRatesByZipcodeResponse.response.compareListDetails.retailerList.Count > 0)
                        {
                            RateComparisionList.ItemsSource = _objComapreRatesByZipcodeResponse.response.compareListDetails.retailerList;
                            XFActivityIndicator.IsVisible = false;
                        }
                        else
                        {
                            DisplayAlert("", "No Retailer is Available", "(X)");
                        }
                    }
                    else
                    {
                        DisplayAlert("", "No Supplier is Available", "(X)");
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private void XFBtnPlanDetail_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            object bindingContext = btn.BindingContext;
            RetailerList objRetailerList = bindingContext as RetailerList;

            App.NavigationPage.Navigation.PushAsync(new RegisterStepOnePage(objRetailerList));
        }

        private void XFPlanDetail_Clicked(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            object bindingContext = image.BindingContext;
            RetailerList objRetailerList = bindingContext as RetailerList;
            App.NavigationPage.Navigation.PushAsync(new PlansDetails(objRetailerList));
        }

        private void XFImgNotification_Tapped(object sender, EventArgs e)
        {
        }

        private void XFImgBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

    }
}