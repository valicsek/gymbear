using System;
using System.Collections.Generic;
using gymbear.ViewModel;
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
            Navigation.PushModalAsync(new WorkoutOnGamePage());
        }
    }
}
