using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.OtherPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsPage : ContentPage
	{
        List<string> listview = new List<string>();
		public NewsPage ()
		{
			InitializeComponent ();
            listview.Add("ajhkjkh");
            listview.Add("lhlh");
            NewsList.ItemsSource = listview;

        }
	}
}