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

        public UserNavigationPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        //[Obsolete]
        //public static string Resolver(string image)
        //{
        //    return string.Format(Device.OnPlatform("{0}", "{0}", "Assets/{0}"), image);
        //}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Settings.IsLoggedIn)
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
            try
            {
                var detail = new NavigationPage(new HomePage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private void GridNews_Tapped(object sender, EventArgs e)
        {
            try
            {
                var detail = new NavigationPage( new NewsPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

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
            try
            {
                var detail = new NavigationPage(new HowSwitchingWorksPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

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
            try
            {
                var detail = new NavigationPage(new WhySwitchPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private void GridServiceArea_Tapped(object sender, EventArgs e)
        {
            try
            {
                var detail = new NavigationPage(new ServiceAreaPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private void GridEnergyGlossary_Tapped(object sender, EventArgs e)
        {
            try
            {
                var detail = new NavigationPage(new EnergyGlossaryPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private void GridFaq_Tapped(object sender, EventArgs e)
        {
            try
            {
                var detail = new NavigationPage(new FaqPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private void GridContactUs_Tapped(object sender, EventArgs e)
        {
            try
            {
                var detail = new NavigationPage(new ContactUsPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private async void GridLogout_Tapped(object sender, EventArgs e)
        {
            try
            {
                var result = await DisplayAlert("", "Are You Sure want to logout!", "Ok", "No");
                if(result)
                {
                    if (Settings.IsLoggedIn)
                    {
                        Settings.IsLoggedIn = false;
                        Settings.TokenCode = string.Empty;
                        var otherPage = new LoginPage();
                        var homePage = App.NavigationPage.Navigation.NavigationStack.First();
                        App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
                        await App.NavigationPage.PopToRootAsync(false);
                    }
                    else
                    {
                        await DisplayAlert("", "please Click on sign in first!", "(X)");
                    }
                }
               
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        private void XFLblLogin_Tapped(object sender, EventArgs e)
        {
            try
            {
                var detail = new NavigationPage(new LoginPage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            //var otherPage = new LoginPage();
            //var homePage = App.NavigationPage.Navigation.NavigationStack.First();
            //App.NavigationPage.Navigation.InsertPageBefore(otherPage, homePage);
            //await App.NavigationPage.PopToRootAsync(false);
        }

        private void ImageProfile_Tapped(object sender, EventArgs e)
        {
            try
            {
                var detail = new NavigationPage(new UserProfilePage());
                App.Navigation = detail.Navigation;
                Detail = detail;
                IsPresented = false;
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }
    }
}