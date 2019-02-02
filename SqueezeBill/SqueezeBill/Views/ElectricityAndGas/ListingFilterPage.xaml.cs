using SqueezeBill.Services.Models.ResponseModels;
using Syncfusion.SfRangeSlider.XForms;
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
	public partial class ListingFilterPage : ContentPage
	{
        private List<RetailerList> list
        {
            get;
            set;
        }

        public ListingFilterPage(List<RetailerList> list)
        {
            InitializeComponent();
            this.list = list.Distinct().ToList();
            List<string> list2 = (from x in list
                                  select x.retailerName).Distinct().ToList();
            dropdownLoadType.ItemsSource = list2;
            //dropdownLoadType.SelectedItem = list2.ElementAt(0);
            IReadOnlyList<Page> navigationStack = App.NavigationPage.Navigation.NavigationStack;
            ElectricityAndGasListing electricityAndGasListing = (ElectricityAndGasListing)navigationStack.ElementAt(navigationStack.Count - 1);
            if (electricityAndGasListing.startDuration != 0)
            {
                rangeslider.RangeStart = (double)electricityAndGasListing.startDuration;
                rangeslider.RangeEnd = (double)electricityAndGasListing.endDuration;
                XFLBFilterDuration.Text = electricityAndGasListing.startDuration + "-" + electricityAndGasListing.endDuration + " Months";
                dropdownLoadType.SelectedItem = electricityAndGasListing.selectedRetailerName;
            }
        }

        private void rangeslider_RangeChanging(object sender, RangeEventArgs e)
        {
            XFLBFilterDuration.Text = e.Start + "-" + e.End + " Months";
        }

        private void XFImgBack_Tapped(object sender, EventArgs e)
        {
            App.NavigationPage.Navigation.PopAsync();
        }

        private void XFLblApply_Tapped(object sender, EventArgs e)
        {
            IReadOnlyList<Page> navigationStack = App.NavigationPage.Navigation.NavigationStack;
            ElectricityAndGasListing electricityAndGasListing = (ElectricityAndGasListing)navigationStack.ElementAt(navigationStack.Count - 2);
            if (dropdownLoadType.SelectedItem != null)
            {
                electricityAndGasListing.selectedRetailerName = dropdownLoadType.SelectedItem.ToString();
            }          
            electricityAndGasListing.startDuration = (int)rangeslider.RangeStart;
            electricityAndGasListing.endDuration = (int)rangeslider.RangeEnd;
            App.NavigationPage.Navigation.PopAsync();
        }
    }
}