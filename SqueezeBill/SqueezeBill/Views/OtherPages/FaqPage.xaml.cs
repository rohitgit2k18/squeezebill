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
	public partial class FaqPage : ContentPage
	{
        #region Variable Declaration    
        private Detail _oldproduct;
        private FAQResponse _objFAQResponse;
        private RestApi _apiService;
        private string _baseUrl;
       
        #endregion
        public FaqPage ()
		{
			InitializeComponent ();
            _objFAQResponse = new FAQResponse();
            _apiService = new RestApi();
            _baseUrl = Domain.Url+Domain.ListofFaqApiConstant;
            BindingContext = _objFAQResponse;
            LoadFaqData();
        }
        private async void LoadFaqData()
        {
            try
            {
                _objFAQResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objFAQResponse);
                var result = _objFAQResponse.response;
                if (result.statusCode == 200)
                {

                    // await DisplayAlert("Alert", "Sucess", "Ok");
                    this.BindingContext = result;

                    GetCompleteFaq.GetCompleteFAQ = result.details;
                }
                else
                {
                    await DisplayAlert("Alert", "No Supplier is Available", "Ok");
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void FAQList_ItemSelected(object sender, ItemTappedEventArgs e)
        {
            var product = e.Item as Detail;
            HideShowPrpduct(product);
        }
        public void HideShowPrpduct(Detail product)
        {
            if (_oldproduct == product)
            {
                product.IsVisible = !product.IsVisible;
                UpdateProduct(product);
            }
            else
            {
                if (_oldproduct != null)
                {
                    _oldproduct.IsVisible = false;
                    UpdateProduct(product);
                }
                product.IsVisible = true;
                UpdateProduct(product);
            }
            //product.IsVisible = true;
            //UpdateProduct(product);
            _oldproduct = product;
        }

        private void UpdateProduct(Detail product)
        {
            var index = _objFAQResponse.response.details.IndexOf(product);
            _objFAQResponse.response.details.Remove(product);
            _objFAQResponse.response.details.Insert(index, product);
        }
    }
}