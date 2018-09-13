using System;
using System.Collections.Generic;
using gymbear.ViewModels;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using gymbear.Services;
using gymbear.Models;

namespace gymbear.Pages
{
    public partial class AddExerciseToWorkoutPage : ContentPage
    {
        AddExerciseToWorkoutViewModel VM;
        public AddExerciseToWorkoutPage()
        {
            InitializeComponent();
            Title = "Add new Exercise";

            this.VM = new AddExerciseToWorkoutViewModel();
            this.BindingContext = this.VM;
            this.VM.Exercises = Service.GetExercises();
        }

        void OnSaveButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                // Save to exercises
                DatabaseService<Exercise>.Insert(this.VM.Exercise);
                // Save for week as well.
                if (!Application.Current.Properties.ContainsKey("Week"))
                {
                    throw new Exception("The week doesn't exists");
                }

                Week _week = Service.GetWeek();
                _week.Workout[Config.AppConfig.CurrentWorkout].Exercises.Add(this.VM.Exercise);
                Service.UploadWeek(_week);

                Service.SaveLocalConfig("BreakTime", 999);

                DisplayAlert("Success", "Succesfully added", "OK");
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        void OnExerciseSearchBarTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string searchedText = (sender as SearchBar).Text;
            this.VM.FilterExercise(searchedText);
        }

        void OnCancelButtonClicked(object sender, System.EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
