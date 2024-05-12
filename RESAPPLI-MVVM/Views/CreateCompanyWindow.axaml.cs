using System;
using System.Runtime.Intrinsics.Arm;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.TestModels;
using RESAPPLI_MVVM.Services;
using Splat;

namespace RESAPPLI_MVVM.Views
{
    public partial class CreateCompanyWindow : Window
    {

        public CreateCompanyWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void InscriptionButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Console.WriteLine("Test affichage");
            var db  = Locator.Current.GetService<iReservationService>();
                Entreprise entreprise = new Entreprise
                {
                    Nom = ((TextBox)this.FindControl<TextBox>("CompanyNameTextBox")).Text,
                    DateCreation = DateOnly.FromDateTime(DateTime.Now)
                };

                Console.WriteLine(entreprise.Nom);
                Console.WriteLine(entreprise.Id);
                db.AddEntreprise(entreprise);

                
                
                // Ajout utilisateur



                var admin = new Utilisateur{
                    Prenom = ((TextBox)this.FindControl<TextBox>("PrenomAdmin")).Text,
                    Nom = ((TextBox)this.FindControl<TextBox>("NomAdmin")).Text,
                    Email = ((TextBox)this.FindControl<TextBox>("MailAdmin")).Text,
                    PasswordHash = Encryption.Encryption.GetSHA256Hash(((TextBox)this.FindControl<TextBox>("PassAdmin")).Text),
                    LastCo = DateTime.Now,
                    CreateAt = DateTime.Now,
                    IdTypeCompte = 1,
                    IdEntreprise = entreprise.Id
                    };

                    db.AddUtilisateur(admin);
                
                
                this.Close();
        }

        private void AnnulerButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Si l'utilisateur clique sur Annuler, fermer simplement la fenêtre
            this.Close();
        }
    }
}
