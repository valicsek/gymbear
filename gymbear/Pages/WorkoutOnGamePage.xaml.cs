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
            this.StartTimer();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void SetupViews()
        {
            NavigationPage.SetHasBackButton(this, false);
            this.Title = "Workout";
        }

        void StartTimer()
        {
            this.VM.StartTimer();
        }

        void OnNextExerciseButtonClicked(object sender, System.EventArgs e)
        {
            var hasMoreExercise = this.VM.ShowNextExercise();
            if (!hasMoreExercise)
            {
                Navigation.PopAsync();
            }
        }

        void OnCancelButtonClicked(object sender, System.EventArgs e)
        {
            // Remove current Page.
            Navigation.PopAsync();
        }

        void OnSetSwitchToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            Switch _sender = sender as Switch;

            if(_sender.IsToggled)
            {
                Navigation.PushModalAsync(new WorkoutBreaktimePage());
            }
        }
    }
}
