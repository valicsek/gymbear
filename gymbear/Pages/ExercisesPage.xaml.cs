using System;
using System.Collections.Generic;
using gymbear.Models;
using gymbear.Services;
using gymbear.ViewModels;
using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class ExercisesPage : ContentPage
    {
        /// <summary>
        /// The Viewmodel of ExerciesPage
        /// </summary>
        ExerciseViewModel VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:gymbear.Pages.ExercisesPage"/> class.
        /// </summary>
        public ExercisesPage()
        {
            InitializeComponent();
            this.VM = new ExerciseViewModel();
            this.BindingContext = this.VM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.VM.Exercises = Services.Service.GetExercises();
        }

        /// <summary>
        /// Ons the exercise delete button clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnExerciseDeleteButtonClicked(object sender, System.EventArgs e)
        {
            Exercise _exercise = (sender as MenuItem).CommandParameter as Exercise;

            try
            {
                DatabaseService<Exercise>.Delete(_exercise);
                this.VM.Exercises = Services.Service.GetExercises();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        /// <summary>
        /// Ons the exercise search text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnExerciseSearchTextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            string searchedText = (sender as SearchBar).Text;
            this.VM.FilterExercise(searchedText);
        }

        /// <summary>
        /// Ons the add exercise button clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnAddExerciseButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddExercisePage());
        }
    }
}
