using SqueezeBill.Services.Models.ResponseModels;
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
        public ElectricityAndGasPlans( ComapreRatesByZipcodeResponse objComapreRatesByZipcodeResponse)
		{
			InitializeComponent ();
            _objComapreRatesByZipcodeResponse = new ComapreRatesByZipcodeResponse();
            _objComapreRatesByZipcodeResponse = objComapreRatesByZipcodeResponse;
            LoadListData();
        }

        private void  LoadListData()
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
                            //this.BindingContext = _objComapreRatesByZipcodeResponse.response;
                            RateComparisionList.ItemsSource = _objComapreRatesByZipcodeResponse.response.compareListDetails.retailerList;
                            XFActivityIndicator.IsVisible = false;
                        }
                        else
                        {
                            DisplayAlert("Alert", "No Retailer is Available", "Ok");
                        }
                    }
                    else
                    {
                         DisplayAlert("Alert", "No Supplier is Available", "Ok");
                    }

                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void XFBtnPlanDetail_Clicked(object sender, EventArgs e)
        {
            var Sender = ((Button)sender);
            var Context = Sender.BindingContext;
            var SelectedItems = Context as RetailerList;

            App.NavigationPage.Navigation.PushAsync(new PlansDetails(SelectedItems));
        }
        
    }
}