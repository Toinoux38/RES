using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.Data;

namespace RESAPPLI_MVVM.Views;

public partial class ReservationsList : Window
{
    public ReservationsList()
    {
        InitializeComponent();
    }
    
    private void PlanningButtonClick(object sender, RoutedEventArgs e)
    {
        
        // Naviguer vers la vue PlanningList
        var db = SingletonMariadb.GetInstance();

        var user = db.Utilisateurs
            .Include(u => u.Entreprise)
            .FirstOrDefault(u => u.Email == mail);
        var planningListView = new PlanningList(user);
        planningListView.Show();
        this.Close();
    }

}