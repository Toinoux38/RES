using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Entreprise
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public DateOnly DateCreation { get; set; }

    public virtual ICollection<Categorieplanning> Categorieplannings { get; } = new List<Categorieplanning>();

    public virtual ICollection<Categoriereservation> Categoriereservations { get; } = new List<Categoriereservation>();

    public virtual ICollection<Planning> Plannings { get; } = new List<Planning>();

    public virtual ICollection<Utilisateur> Utilisateurs { get; } = new List<Utilisateur>();
}
