using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.Data;

namespace RESAPPLI_MVVM.Views;

public partial class LoginWindow : Window
{
    public LoginWindow()
    {
        InitializeComponent();
    }

    private void LoginAction(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string mail = ((TextBox)this.FindControl<TextBox>("MailAdmin")).Text;
        string password = Encryption.Encryption.GetSHA256Hash(((TextBox)this.FindControl<TextBox>("PassAdmin")).Text);

        var db = SingletonMariadb.GetInstance();

        var user = db.Utilisateurs
            .Include(u => u.Entreprise)
            .FirstOrDefault(u => u.Email == mail);


        if (user != null) // l'utilisateur a été trouvé
        {

            if (user.PasswordHash == password) // Matching
            {
                Console.WriteLine("Login Reussis");
                PlanningList viewPlanning = new PlanningList(user);
                viewPlanning.Show();
            }
            else // Fail
            {
                Console.WriteLine("Login Failed");
            }
            
        }
        else
        {
            Console.WriteLine("L'utilisateur n'existe pas");
        }
        
    }
}