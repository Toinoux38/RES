using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Utilisateur
{
    public int Id { get; set; }

    public string? Prenom { get; set; }

    public string? Nom { get; set; }

    public string? Email { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? LastCo { get; set; }

    public int? IdTypeCompte { get; set; }

    public int? IdEntreprise { get; set; }

    public virtual Entreprise? IdEntrepriseNavigation { get; set; }

    public virtual Typecompte? IdTypeCompteNavigation { get; set; }

    public virtual ICollection<Log> Logs { get; } = new List<Log>();

    public virtual ICollection<Reservation> IdReservations { get; } = new List<Reservation>();
}
