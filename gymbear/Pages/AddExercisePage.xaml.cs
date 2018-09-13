using System;
using System.Collections.Generic;
using gymbear.ViewModels;
using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class AddExercisePage : ContentPage
    {
        /// <summary>
        /// The Viewmodel of AddExercisePage
        /// </summary>
        AddExerciseViewModel VM;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:gymbear.Pages.AddExercisePage"/> class.
        /// </summary>
        public AddExercisePage()
        {
            InitializeComponent();
            this.VM = new AddExerciseViewModel();
            this.BindingContext = this.VM;
        }

        /// <summary>
        /// Ons the save button clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void OnSaveButtonClicked(object sender, System.EventArgs e)
        {
            try
            {
                this.VM.AddExerciseToDatabase(VM.Exercise);
                DisplayAlert("Success", "1 new exercise added.", "OK");
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        void OnCancelButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
