using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Categoriereservation
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public DateOnly? DateCreation { get; set; }

    public int? IdEntreprise { get; set; }

    public virtual Entreprise? IdEntrepriseNavigation { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
