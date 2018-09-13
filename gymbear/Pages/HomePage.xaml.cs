using System;
using System.Collections.Generic;
using gymbear.ViewModels;
using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomeViewModel VM;
        public HomePage()
        {
            InitializeComponent();
            this.VM = new HomeViewModel();
            this.BindingContext = this.VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            setupViews();
        }

        void setupViews()
        {
            this.HomeImage.Source = ImageSource.FromResource("gymbear.Assets.Images.man-logo-home.png");
        }

        void OnStartWorkoutButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new WorkoutOnGamePage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
