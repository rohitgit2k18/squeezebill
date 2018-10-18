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
		public ElectricityAndGasPlans ()
		{
			InitializeComponent ();
		}

       

        private void Button_licked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlansDetails());
        }
    }
}