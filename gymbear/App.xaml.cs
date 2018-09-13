using System;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace gymbear
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitializeDatabase();

            MainPage mainPage = new MainPage() { Title = "Gymbear" };
            MainPage = new NavigationPage(mainPage);
        }

        /// <summary>
        /// Initializes the database.
        /// </summary>
        void InitializeDatabase()
        {
            Services.Service.InitializeWeek();
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
