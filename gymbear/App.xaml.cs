using System;
using System.Diagnostics;
using System.IO;
using gymbear.Services;
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
            InitalizeDefaultSettings();

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

        /// <summary>
        /// Initalizes the default settings for Workout
        /// </summary>
        void InitalizeDefaultSettings()
        {
            if (!Application.Current.Properties.ContainsKey("BreakTime"))
                Service.SaveLocalConfig("BreakTime", 45);
            if (!Application.Current.Properties.ContainsKey("BreakTime"))
                Service.SaveLocalConfig("BreakTime", 3);
            if (!Application.Current.Properties.ContainsKey("BreakTime"))
                Service.SaveLocalConfig("BreakTime", 10);
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
