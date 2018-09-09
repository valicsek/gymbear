using System;
using System.Collections.Generic;
using gymbear.ViewModels;
using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class WorkoutBreaktimePage : ContentPage
    {
        public WorkoutOnGameViewModel VM;

        public WorkoutBreaktimePage()
        {
            InitializeComponent();
            this.VM = new WorkoutOnGameViewModel();
            this.BindingContext = this.VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SetupTheTimer();
        }

        void SetupTheTimer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if (this.VM.BreakTimeLeft == 0) return false;
                this.VM.BreakTimeLeft--;
                return true;
            });
        }

        void OnSkipButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
