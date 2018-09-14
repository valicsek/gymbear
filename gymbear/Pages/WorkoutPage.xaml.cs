using System;
using System.Collections.Generic;
using gymbear.Models;
using gymbear.ViewModels;
using Xamarin.Forms;
using System.Linq;
using gymbear.Services;

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

        /// <summary>
        /// The start workout button clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnStartWorkoutButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                Service.SaveLocalConfig("BreakTime", this.VM.BreakTime);
                Service.SaveLocalConfig("NuOfSets", this.VM.NuOfSets);
                Service.SaveLocalConfig("NuOfRepetitions", this.VM.NuOfRepetitions);

                Navigation.PushAsync(new WorkoutOnGamePage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        /// <summary>
        /// The plus button clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnPlusButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddExerciseToWorkoutPage());
        }

        /// <summary>
        /// Ons the delete workout exercise action clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnDeleteWorkoutExerciseActionClicked(object sender, System.EventArgs e)
        {
            var _obj = (Exercise)(sender as MenuItem).CommandParameter;
            try
            {
                Week week = Services.Service.GetWeek();
                week.Workout[this.VM.CurrentWorkoutIndex].Exercises.Remove(_obj);
                Service.UploadWeek(week);
                DisplayAlert("Info", "Successfuly deleted", "OK");
                this.VM.NoExerciseHasBeenAdded = week.Workout[this.VM.CurrentWorkoutIndex].Exercises.Count == 0;
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        /// <summary>
        /// The delete exercise action clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnDeleteExerciseActionClicked(object sender, System.EventArgs e)
        {
            var _obj = (Exercise)(sender as MenuItem).CommandParameter;
            try
            {
                Services.DatabaseService<Exercise>.Delete(_obj);

                Week week = Services.Service.GetWeek();
                week.Workout[this.VM.CurrentWorkoutIndex].Exercises.Remove(_obj);
                Service.UploadWeek(week);
                DisplayAlert("Info", "Successfuly deleted", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
