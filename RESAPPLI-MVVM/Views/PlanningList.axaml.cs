using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using RESAPPLI_MVVM.Data;
using RESAPPLI_MVVM.Models;

namespace RESAPPLI_MVVM.Views;

public partial class PlanningList : Window
{
    private Utilisateur current_user;

    private Entreprise current_entreprise;
    
    // On a besoin d'un utilisateur
    public PlanningList(Utilisateur user)
    {
        InitializeComponent();
        Init(user);
    }

    public void Init(Utilisateur user)
    {
        SingletonMariadb db = SingletonMariadb.GetInstance();
        current_user = user;
        current_entreprise = user.Entreprise;
       
        // Message de bienvenue
        string WelcomeMessage = $"Bienvenue {user.Nom} sur l'entreprise {current_entreprise.Nom}";
        this.FindControl<TextBlock>("WelcomeTXT").Text = WelcomeMessage;
        
        
        // Affichage des plannings

        DataGrid datagrid = this.Find<DataGrid>("PlanningDataGrid");
        datagrid.ItemsSource = current_entreprise.Plannings;

    }
}