using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using RESAPPLI_MVVM.TestModels;
using RESAPPLI_MVVM.Services;
using Splat;
namespace RESAPPLI_MVVM.Views
{
    public partial class CreateReservationWindow : Window
    {
        public CreateReservationWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Saving reservation...");
            var db = Locator.Current.GetService<iReservationService>();

            // Convert DateTimeOffset to DateTime for DateReservation
            var selectedDate = this.FindControl<DatePicker>("DayPicker").SelectedDate?.DateTime ?? DateTime.Today;

            // Convert TimeSpan to TimeOnly for HeureDebut and HeureFin
            var selectedStartTime = this.FindControl<TimePicker>("StartHourPicker").SelectedTime ?? TimeSpan.Zero;
            var selectedEndTime = this.FindControl<TimePicker>("EndHourPicker").SelectedTime ?? TimeSpan.Zero;

            // Ensure the start time is before the end time
            if (selectedStartTime >= selectedEndTime)
            {
                
                
                var box = MessageBoxManager
                    .GetMessageBoxStandard("Intervalle invalide", "Start time must be before end time.");

                var result = await box.ShowAsync();
                return;
            }

            // Create a new reservation object with the input data
            var reservation = new Reservation
            {
                DateReservation = DateOnly.FromDateTime(selectedDate),
                HeureDebut = TimeOnly.FromTimeSpan(selectedStartTime),
                HeureFin = TimeOnly.FromTimeSpan(selectedEndTime),
                Note = this.FindControl<TextBox>("NoteTextBox").Text,
                IdPlanning = 1, // Assuming a default value
                IdCategorie = 1 // Assuming a default value
            };

            db.AddReservation(reservation);

            Console.WriteLine("Reservation saved.");
            this.Close();
        }
    }
}