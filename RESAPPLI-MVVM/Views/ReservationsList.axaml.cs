using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;

using RESAPPLI_MVVM.Services;
using RESAPPLI_MVVM.TestModels;
using Splat;

namespace RESAPPLI_MVVM.Views;

public partial class ReservationsList : Window
{
    private readonly iReservationService dbService;
    public ReservationsList()
    {
        dbService = Locator.Current.GetService<iReservationService>();
        InitializeComponent();
        LoadReservations();
    }
    
    private void PlanningButtonClick(object sender, RoutedEventArgs e)
    {
        
        this.Close();
    }
    
    private void LoadReservations()
    {
        var reservations = dbService.GetReservations();
        ItemsControl.ItemsSource = reservations;
        
    }
    private void DeleteButtonClick(object sender, RoutedEventArgs e)
    {
        var reservation = (sender as Button)?.DataContext as Reservation;

        if (reservation != null)
        {
            dbService.DeleteReservation(reservation);
        
            LoadReservations();
        }
    }
    private void AddReservationButton_Click(object sender, RoutedEventArgs e)
    {
        var createReservationWindow = new CreateReservationWindow();
        createReservationWindow.ShowDialog(this);
    }
    
    

}