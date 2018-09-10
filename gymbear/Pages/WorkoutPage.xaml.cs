using System;
using System.Collections.Generic;
using gymbear.ViewModels;
using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutModelView VM { get; set; }

        public WorkoutPage()
        {
            InitializeComponent();
            this.VM = new WorkoutModelView();
            this.BindingContext = this.VM;
        }

        void OnStartWorkoutButtonClicked(object sender, System.EventArgs e)
        {
            Application.Current.Properties["BreakTime"] = this.VM.BreakTime;
            Application.Current.Properties["NuOfSets"] = this.VM.NuOfSets;
            Application.Current.Properties["NuOfRepetitions"] = this.VM.NuOfRepetitions;
            Navigation.PushAsync(new WorkoutOnGamePage());
        }
    }
}
