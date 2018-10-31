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
		public ListingFilterPage ()
		{
			InitializeComponent ();
		}

        private void rangeslider_RangeChanging(object sender, Syncfusion.SfRangeSlider.XForms.RangeEventArgs e)
        {
            var x = e.Start;
            var y = e.End;
        }

        
    }
}