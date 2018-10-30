using SqueezeBill.Helpers;
using SqueezeBill.Views.Home;
using SqueezeBill.Views.OtherPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqueezeBill.Views.Accounts.UserProfile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserNavigationPage : MasterDetailPage
    {
		public UserNavigationPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(Settings.IsLoggedIn)
            {
                XFStackProfilePic.IsVisible = true;
                XFLblSignIn.IsVisible = false;
                XFGridPic.Padding = new Thickness(0, 0, 0, 0);
            }
            else
            {
                XFLblSignIn.IsVisible = true;
                XFStackProfilePic.IsVisible = false;
                XFGridPic.Padding = new Thickness(0, 20, 0, 20);
            }
        }
        private void GridHome_Tapped(object sender, EventArgs e)
        {

            var detail = new NavigationPage(new HomePage());
            App.DetailPage = new HomePage();
            detail.Title = "HomePage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridNews_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new NewsPage());
            App.DetailPage = new NewsPage();
            detail.Title = "NewsPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
            //var detail4 = new NavigationPage(new NewsPage());
            //var detail = App.NavigationPage = detail4;
            //App.DetailPage = new NewsPage();
            //detail.Title = "HomePage";
            //App.NavigationPage = detail;
            //Detail = detail;
            //IsPresented = false;
        }

        private void GridHowSwitchWork_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new HowSwitchingWorksPage());
            App.DetailPage = new HowSwitchingWorksPage();
            detail.Title = "HowSwitchingWorksPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
            //var detail4 = new NavigationPage(new HowSwitchingWorksPage());
            //var detail = App.NavigationPage = detail4;
            //App.DetailPage = new HowSwitchingWorksPage();
            //detail.Title = "HomePage";
            //App.NavigationPage = detail;
            //Detail = detail;
            //IsPresented = false;
        }

        private void GridWhySwitch_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new WhySwitchPage());
            App.DetailPage = new WhySwitchPage();
            detail.Title = "WhySwitchPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridServiceArea_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new ServiceAreaPage());
            App.DetailPage = new ServiceAreaPage();
            detail.Title = "ServiceAreaPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridEnergyGlossary_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new EnergyGlossaryPage());
            App.DetailPage = new EnergyGlossaryPage();
            detail.Title = "EnergyGlossaryPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridFaq_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new FaqPage());
            App.DetailPage = new FaqPage();
            detail.Title = "FaqPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridContactUs_Tapped(object sender, EventArgs e)
        {
            var detail = new NavigationPage(new ContactUsPage());
            App.DetailPage = new ContactUsPage();
            detail.Title = "ContactUsPage";
            App.Navigation = detail.Navigation;
            Detail = detail;
            IsPresented = false;
        }

        private void GridLogout_Tapped(object sender, EventArgs e)
        {

        }

        private async void XFLblLogin_Tapped(object sender, EventArgs e)
        {
            var otherPage = new LoginPage();
            var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            await App.NavigationPage.PopToRootAsync(false);
        }
    }
}