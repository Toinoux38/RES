using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.Services;
using RESAPPLI_MVVM.TestModels;
using Splat;
using static RESAPPLI_MVVM.Views.MainWindow;
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

        var db = Locator.Current.GetService<iReservationService>();

        Utilisateur user = db.FindUtilisateurByMail(mail);

        if (user != null) // l'utilisateur a été trouvé
        {

            if (user.PasswordHash == password) // Matching
            {
                Console.WriteLine("Login Reussis");
                PlanningList viewPlanning = new PlanningList(user);
                viewPlanning.Show();
                this.Close();


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
    private void TextBox_KeyUp(object sender, Avalonia.Input.KeyEventArgs e)
    {
        if (e.Key == Avalonia.Input.Key.Enter)
        {
            // Call the same logic as LoginAction
            LoginAction(sender, e);
        }
    }
}