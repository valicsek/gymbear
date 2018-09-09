using System;
using System.Collections.Generic;
using gymbear.ViewModels;
using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class WorkoutOnGamePage : ContentPage
    {
        public WorkoutOnGameViewModel VM;

        public WorkoutOnGamePage()
        {
            InitializeComponent();
            this.VM = new WorkoutOnGameViewModel();
            this.BindingContext = this.VM;
            SetupViews();
        }

        void SetupViews()
        {
            NavigationPage.SetHasBackButton(this, false);
            this.Title = "Workout";
        }

        void OnNextExerciseButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new WorkoutBreaktimePage());
        }

        void OnCancelButtonClicked(object sender, System.EventArgs e)
        {
            // Remove current Page.
            Navigation.PopAsync();
        }
    }
}
