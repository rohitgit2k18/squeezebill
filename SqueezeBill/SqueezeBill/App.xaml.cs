﻿using SqueezeBill.Views.Accounts;
using SqueezeBill.Views.Accounts.UserProfile;
using SqueezeBill.Views.Accounts.UserRegistration;
using SqueezeBill.Views.Home;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SqueezeBill
{
    public partial class App : Application
    {
        public static INavigation Navigation;
        public static Page DetailPage;
        public static NavigationPage NavigationPage { get; set; }
        public App()
        {
            InitializeComponent();
            NavigationPage= new NavigationPage(new UserNavigationPage());
             MainPage = NavigationPage;
            //MainPage = new UserNavigationPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
