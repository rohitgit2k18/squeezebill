using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.Accounts.UserRegistration
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DisclousersPage : ContentPage
	{
		public DisclousersPage ()
		{
			InitializeComponent ();
            WebViewDiscloser.Source = "http://125.63.101.163:150/Content/ConstellationTerms109491.pdf";

        }
	}
}