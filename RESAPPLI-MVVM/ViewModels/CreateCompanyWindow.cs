using System;
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
        private DbContextOptionsBuilder dbContextOptionsBuilder;

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
                db.Entreprises.Add(entreprise);
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
