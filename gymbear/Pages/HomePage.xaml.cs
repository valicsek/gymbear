using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
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
    }
}
