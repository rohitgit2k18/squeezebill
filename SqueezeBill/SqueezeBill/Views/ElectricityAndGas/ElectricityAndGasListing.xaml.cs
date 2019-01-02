using Plugin.Connectivity;
using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
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
	public partial class ElectricityAndGasListing : ContentPage
	{
        #region Variable Declaration
        private ComapreRatesByZipcodeRequest _objComapreRatesByZipcodeRequest;
         private ComapreRatesByZipcodeResponse _objComapreRatesByZipcodeResponse;
         private RestApi _apiService;
         private string _baseUrl;

        public int startDuration = 0;
        public int endDuration = 0;
        public string selectedRetailerName = "";
        
        public SupplierList selectedCompany;

        private CListResponse result = new CListResponse();

        #endregion
        public ElectricityAndGasListing(ComapreRatesByZipcodeRequest ObjComapreRatesByZipcodeRequest)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "Back");
            _objComapreRatesByZipcodeRequest = new ComapreRatesByZipcodeRequest();
            _objComapreRatesByZipcodeRequest = ObjComapreRatesByZipcodeRequest;
            _objComapreRatesByZipcodeResponse = new ComapreRatesByZipcodeResponse();
            _apiService = new RestApi();
            if (_objComapreRatesByZipcodeRequest.requestSearch.isElectricity)
            {
                XFLabelTitle.Text = "Electricity";
            }
            else
            {
                XFLabelTitle.Text = "Gas";
            }
            _baseUrl = Domain.Url + Domain.LoadDataByZipCodeApiConstant;
            LoadSupplierAndRetailerList();
            base.BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!string.IsNullOrEmpty(selectedRetailerName))
            {
                IEnumerable<RetailerList> itemsSource = from x in result.compareListDetails.retailerList
                                                        where x.retailerName == selectedRetailerName && x.duration >= startDuration && x.duration <= endDuration
                                                        select x;
                RateComparisionList.ItemsSource = itemsSource;
            }
        }

        private async void LoadSupplierAndRetailerList()
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
                    _objComapreRatesByZipcodeResponse = await _apiService.ListofRetailerPostAsync(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objComapreRatesByZipcodeRequest);
                    result = _objComapreRatesByZipcodeResponse.response;
                    if (result.statusCode == 200)
                    {
                        if (result.compareListDetails.supplierList.Count <= 0)
                        {
                            await DisplayAlert("Alert", "No Supplier is Available", "Ok");
                        }
                        else
                        {
                            //List<SupplierList> cl = result.compareListDetails.supplierList;
                            //result.compareListDetails.supplierList.AddRange(cl);
                            //result.compareListDetails.supplierList.AddRange(result.compareListDetails.supplierList);
                            //for (int i = 0; i < result.compareListDetails.supplierList.Count; i++)
                            //{
                            //    string cn = result.compareListDetails.supplierList.ElementAt(i).companyName;
                            //    result.compareListDetails.supplierList.ElementAt(i).companyName = cn + i;
                            //}

                            selectedCompany = result.compareListDetails.supplierList.ElementAt(0);
                            XFLBKCompanyRate.Text = $"{selectedCompany.rate:0.00}" + "c";
                            XFLBLCompanyName.Text = result.compareListDetails.supplierList.ElementAt(0).companyName;

                            XFListCompanyName.ItemsSource = result.compareListDetails.supplierList;
                            
                            //select x.companyName;
                            //XFListCompanyName.SelectedItem = selectedCompany.companyName;
                            
                            if (result.compareListDetails.supplierList.Count <= 5)
                            {
                                XFListCompanyName.HeightRequest = (double)(50 * result.compareListDetails.supplierList.Count);
                            }
                            else
                            {
                                XFListCompanyName.HeightRequest = 250.0;
                            }
                            
                            if (result.compareListDetails.retailerList.Count <= 0)
                            {
                                await DisplayAlert("Alert", "No Retailer is Available", "Ok");
                            }
                            else
                            {
                                base.BindingContext = result;
                                RateComparisionList.ItemsSource = result.compareListDetails.retailerList;
                                XFActivityIndicator.IsVisible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        private void XFBtnLoadPlans_Clicked(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new ElectricityAndGasPlans(_objComapreRatesByZipcodeResponse));
        }

        private void XFBtnSelectPlan_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            object bindingContext = btn.BindingContext;
            RetailerList objRetailerList = bindingContext as RetailerList;

            App.NavigationPage.Navigation.PushAsync(new RegisterStepOnePage(objRetailerList));
        }

        private void XFImgFilter_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PushAsync(new ListingFilterPage(result.compareListDetails.retailerList));
        }

        private void XFPlanDetail_Clicked(object sender, EventArgs e)
        {
            Image image = (Image)sender;
            object bindingContext = image.BindingContext;
            RetailerList objRetailerList = bindingContext as RetailerList;
            App.NavigationPage.Navigation.PushAsync(new PlansDetails(objRetailerList));
        }

        private void XFImgBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void XFLblCompany_Clicked(object sender, EventArgs e)
        {
            if (result.compareListDetails.supplierList.Count != 0)
            {
                XFCVCompanyPopup.IsVisible = true;
            }
            else
            {
                DisplayAlert("Alert", "No Supplier is Available", "Ok");
            }
        }

        private void XFPopupCancel_Clicked(object sender, EventArgs e)
        {
            XFCVCompanyPopup.IsVisible = false;
        }

        private void XFListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            XFCVCompanyPopup.IsVisible = false;
            SupplierList sl = (SupplierList)e.SelectedItem;
            selectedCompany = result.compareListDetails.supplierList.Where(x => x.companyName == sl.companyName).FirstOrDefault();
            RateComparisionList.ItemsSource = result.compareListDetails.retailerList.Where(x => x.companyId == selectedCompany.companyId);

            XFLBLCompanyName.Text = selectedCompany.companyName;
            XFLBKCompanyRate.Text = $"{selectedCompany.rate:0.00}" + "c";
        }
    }
}