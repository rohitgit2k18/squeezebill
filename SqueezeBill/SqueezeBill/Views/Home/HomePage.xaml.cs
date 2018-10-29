using SqueezeBill.Services.ApiHandler;
using SqueezeBill.Services.Models;
using SqueezeBill.Services.Models.RequestModels;
using SqueezeBill.Services.Models.ResponseModels;
using SqueezeBill.Views.Accounts;
using SqueezeBill.Views.ElectricityAndGas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTransport.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.Home
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        #region Variable Declaration
        public static int selectedConsumer = 0;
        public static int selectedElement = 0;
        List<KeyValuePair<string, string>> listTabsConsumerTypes;
        List<KeyValuePair<string, string>> listTabsElementTypes;
        List<string> imagesNameConsumer;
        List<string> imagesNameElement;
        private ComapreRatesByZipcodeRequest _objComapreRatesByZipcodeRequest;
       
        #endregion
        public HomePage ()
		{
			InitializeComponent ();
            //NavigationPage.SetHasNavigationBar(this, false);
            _objComapreRatesByZipcodeRequest = new ComapreRatesByZipcodeRequest();
            
            listTabsConsumerTypes = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ImgResidence", "Residence"),
                    new KeyValuePair<string, string>("ImgCommercial", "Commercial")

                };
            listTabsElementTypes = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("ImgElctricity", "Elctricity"),
                    new KeyValuePair<string, string>("ImgGas", "Gas")

                };
            imagesNameConsumer = new List<string>()
                {
                    "residence" , "commercial"
                };
            imagesNameElement = new List<string>()
                {
                    "electicity" , "gas"
                };
            _objComapreRatesByZipcodeRequest.requestSearch.isResidential = true;
            _objComapreRatesByZipcodeRequest.requestSearch.isElectricity = true;
            _objComapreRatesByZipcodeRequest.requestFilterSearch.supplierName = string.Empty;
            _objComapreRatesByZipcodeRequest.requestFilterSearch.terms = 0;
        }

        private void XFBtnCompareRates_Clicked(object sender, EventArgs e)
        {
            try
            {
                string Zipcode= XFEntryZipCode.Text;
                if(!string.IsNullOrEmpty(Zipcode))
                {
                    _objComapreRatesByZipcodeRequest.requestSearch.zipCode = Zipcode;

                App.NavigationPage.Navigation.PushAsync(new ElectricityAndGasListing(_objComapreRatesByZipcodeRequest));
                }
                else
                {
                    DisplayAlert("Alert", "Please Enter the ZipCode", "Ok");
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
           
        }

        void SelectTabConsumer(Grid grid, int currentIndex, int newIndex)
        {
            // Select new tab
            var imgPosts = grid.FindByName<Image>(listTabsConsumerTypes.ElementAt(newIndex).Key);      
            imgPosts.Source = ImageSource.FromFile(imagesNameConsumer.ElementAt(newIndex) + "yellow.png");
           
            // Unselect seleceted tab
            var selectedImage = grid.Parent.FindByName<Image>(listTabsConsumerTypes.ElementAt(currentIndex).Key);           
            selectedImage.Source = ImageSource.FromFile(imagesNameConsumer.ElementAt(currentIndex) + ".png");
           
            selectedConsumer = newIndex;
        }

        void SelectTabElement(Grid grid, int currentIndex, int newIndex)
        {
            // Select new tab
            var imgPosts = grid.FindByName<Image>(listTabsElementTypes.ElementAt(newIndex).Key);
            
            imgPosts.Source = ImageSource.FromFile(imagesNameElement.ElementAt(newIndex) + "yellow.png");
            
            // Unselect seleceted tab
            var selectedImage = grid.Parent.FindByName<Image>(listTabsElementTypes.ElementAt(currentIndex).Key);
            
            selectedImage.Source = ImageSource.FromFile(imagesNameElement.ElementAt(currentIndex) + ".png");

            selectedElement = newIndex;
        }
        private void XFGridResidence_Tapped(object sender, EventArgs e)
        {
            if (selectedConsumer != 0)
            {
                Grid grid = ((Grid)sender);
                SelectTabConsumer(grid, selectedConsumer, 0);
               _objComapreRatesByZipcodeRequest.requestSearch.isResidential = true;
                _objComapreRatesByZipcodeRequest.requestSearch.isCommercial = false;
                //ContentPresenter contentPresenter = grid.FindByName<ContentPresenter>("content");

                //contentPresenter.Content = (new Helpers()).Content;

                // await Helpers.Instance.GetRuntimeLocationPermission(5000);
            }
        }

        private void XFGridCommercial_Tapped(object sender, EventArgs e)
        {
            if (selectedConsumer != 1)
            {
                Grid grid = ((Grid)sender);
                SelectTabConsumer(grid, selectedConsumer, 1);
                _objComapreRatesByZipcodeRequest.requestSearch.isResidential = false;
                _objComapreRatesByZipcodeRequest.requestSearch.isCommercial = true;
            }
        }

        private void XFGridElectricity_Tapped(object sender, EventArgs e)
        {
            if (selectedElement != 0)
            {
                Grid grid = ((Grid)sender);
                SelectTabElement(grid, selectedElement, 0);
                _objComapreRatesByZipcodeRequest.requestSearch.isElectricity = true;
                _objComapreRatesByZipcodeRequest.requestSearch.isGas = false;

            }
        }

        private void XFGridGas_Tapped(object sender, EventArgs e)
        {
            if (selectedElement != 1)
            {
                Grid grid = ((Grid)sender);
                SelectTabElement(grid, selectedElement, 1);
                _objComapreRatesByZipcodeRequest.requestSearch.isElectricity = false;
                _objComapreRatesByZipcodeRequest.requestSearch.isGas = true;

            }
        }
    }
}