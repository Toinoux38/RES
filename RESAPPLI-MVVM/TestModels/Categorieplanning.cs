using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Categorieplanning
{
    public int Id { get; set; }

    public string? Nom { get; set; }

    public DateOnly? DateCreation { get; set; }

    public int? IdEntreprise { get; set; }

    public virtual Entreprise? IdEntrepriseNavigation { get; set; }

    public virtual ICollection<Planning> Plannings { get; } = new List<Planning>();
}
