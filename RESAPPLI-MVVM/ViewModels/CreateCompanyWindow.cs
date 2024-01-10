using System;
using System.Runtime.Intrinsics.Arm;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.EntityFrameworkCore;
using RESAPPLI_MVVM.Data;
using RESAPPLI_MVVM.Models;

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
            var db = SingletonMariadb.GetInstance();
                var entreprise = new Entreprise
                {
                    Nom = ((TextBox)this.FindControl<TextBox>("CompanyNameTextBox")).Text,
                    DateCreation = DateTime.Today // Vous pouvez remplacer par la date d'inscription fournie par l'utilisateur
                };

                Console.WriteLine(entreprise.Nom);
                Console.WriteLine(entreprise.ID);
                db.Entreprises.Add(entreprise);

                db.SaveChanges();
                
                // Ajout utilisateur



                var admin = new Utilisateur{
                    Prenom = ((TextBox)this.FindControl<TextBox>("PrenomAdmin")).Text,
                    Nom = ((TextBox)this.FindControl<TextBox>("NomAdmin")).Text,
                    Email = ((TextBox)this.FindControl<TextBox>("MailAdmin")).Text,
                    PasswordHash = Encryption.Encryption.GetSHA256Hash(((TextBox)this.FindControl<TextBox>("PassAdmin")).Text),
                    LastConnection = DateTime.Now,
                    CreateAt = DateTime.Now,
                    TypeCompteId = 1,
                    EntrepriseId = entreprise.ID 
                    };

                    db.Utilisateurs.Add(admin);
                
                db.SaveChanges();
                this.Close();
        }

        private void AnnulerButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Si l'utilisateur clique sur Annuler, fermer simplement la fenêtre
            this.Close();
        }
    }
}
