using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using RESAPPLI_MVVM.TestModels;
using RESAPPLI_MVVM.Services;
using Splat;

namespace RESAPPLI_MVVM.Views
{
    public partial class CreateReservationWindow : Window
    {
        private readonly iReservationService _reservationService;

        public CreateReservationWindow()
        {
            InitializeComponent();
            _reservationService = Locator.Current.GetService<iReservationService>();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Convert DateTimeOffset to DateTime for DateReservation
            DateTime dateReservation = DayPicker.SelectedDate?.DateTime ?? DateTime.Today;

            // Convert TimeSpan to TimeOnly for HeureDebut and HeureFin
            TimeSpan heureDebut = StartHourPicker.SelectedTime ?? TimeSpan.Zero;
            TimeSpan heureFin = EndHourPicker.SelectedTime ?? TimeSpan.Zero;

            // Create a new reservation object with the input data
            var reservation = new Reservation
            {
                DateReservation = new DateOnly(dateReservation.Year, dateReservation.Month, dateReservation.Day),
                HeureDebut = new TimeOnly(heureDebut.Hours, heureDebut.Minutes),
                HeureFin = new TimeOnly(heureFin.Hours, heureFin.Minutes),
                Note = NoteTextBox.Text
            };

            // Add the reservation to the database using the service
            _reservationService.AddReservation(reservation);

            // Close the window
            Close();
        }
    }
}