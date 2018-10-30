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
                XFActivityIndicator.IsVisible = true;
                _objFAQResponse = await _apiService.GetAsyncData_GetApi(new Get_API_Url().CommonBaseApi(_baseUrl), false, new HeaderModel(), _objFAQResponse);
                var result = _objFAQResponse.response;
                if (result.statusCode == 200)
                {
                    XFActivityIndicator.IsVisible = false;
                    // await DisplayAlert("Alert", "Sucess", "Ok");
                    foreach (var items in result.details)
                    {
                        items.IconText = "+";
                    }
                    this.BindingContext = result;

                    GetCompleteFaq.GetCompleteFAQ = result.details;
                }
                else
                {
                    XFActivityIndicator.IsVisible = false;
                    await DisplayAlert("Alert", "No Supplier is Available", "Ok");
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
                XFActivityIndicator.IsVisible = false;
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
                if(product.IconText == "+")
                {
                    product.IconText = "-";
                }
                else
                {
                    product.IconText = "+";
                }
                
                UpdateProduct(product);
            }
            else
            {
                if (_oldproduct != null)
                {
                    _oldproduct.IsVisible = false;
                    _oldproduct.IconText = "+";
                    UpdateProduct(product);
                }
                product.IsVisible = true;
                product.IconText = "-";
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