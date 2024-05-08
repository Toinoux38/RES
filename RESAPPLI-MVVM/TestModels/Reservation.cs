using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Reservation
{
    public int Id { get; set; }

    public DateOnly? DateReservation { get; set; }

    public TimeOnly? HeureDebut { get; set; }

    public TimeOnly? HeureFin { get; set; }

    public int? IdPlanning { get; set; }

    public int? IdCategorie { get; set; }

    public virtual Categoriereservation? IdCategorieNavigation { get; set; }

    public virtual Planning? IdPlanningNavigation { get; set; }

    public virtual ICollection<Utilisateur> IdUtilisateurs { get; } = new List<Utilisateur>();
}
