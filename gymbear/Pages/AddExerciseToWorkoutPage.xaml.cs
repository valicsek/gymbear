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
                if (ExerciseListView.SelectedItem == null)
                {
                    // Save to exercises
                    DatabaseService<Exercise>.Insert(this.VM.Exercise);
                }

                Week _week = Service.GetWeek();
                _week.Workout[Config.AppConfig.CurrentWorkout].Exercises.Add(this.VM.Exercise);
                Service.UploadWeek(_week);
                
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
