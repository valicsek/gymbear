using System;
using System.Collections.Generic;
using AudioToolbox;
using gymbear.ViewModels;
using Xamarin.Forms;

namespace gymbear.Pages
{
    public partial class WorkoutBreaktimePage : ContentPage
    {
        public WorkoutOnGameViewModel VM;
        private SystemSound systemSound;

        public WorkoutBreaktimePage()
        {
            InitializeComponent();
            this.VM = new WorkoutOnGameViewModel();
            this.BindingContext = this.VM;

            // You can find more sound here:
            // https://forums.xamarin.com/discussion/35751/how-the-hell-i-can-play-a-simple-ios-system-sound
            this.systemSound = new SystemSound(1005);
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
                if (this.VM.BreakTimeLeft == 0)
                {
                    NotifyUserToStopRestWithSoundEffect();
                    Navigation.PopModalAsync();
                    return false;
                }
                this.VM.BreakTimeLeft--;
                return true;
            });
        }

        //
        // This function called when the timer has been finished
        // It basically notifies the user.
        // 
        void NotifyUserToStopRestWithSoundEffect()
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.systemSound.PlayAlertSound();
            }
            // TODO: Add Android Alert sound as well.
        }

        void OnSkipButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
