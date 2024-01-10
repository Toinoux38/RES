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
       
        Console.WriteLine("BEGIN DEBUG");
        Console.WriteLine(user);
        Console.WriteLine("ENTREPRISE");
        Console.WriteLine(user.Entreprise);
        Console.WriteLine("USER NOM");
        Console.WriteLine(user.Nom);
        Console.WriteLine("ENTREPRISE NOM");
        Console.WriteLine(user.Entreprise.Nom);
        
        string WelcomeMessage = $"Bienvenue {user.Nom} sur l'entreprise {current_entreprise.Nom}";
        this.FindControl<TextBox>("WelcomeTXT").Text = WelcomeMessage;

    }
}