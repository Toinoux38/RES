using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Typecompte
{
    public int Id { get; set; }

    public string? Libelle { get; set; }

    public virtual ICollection<Utilisateur> Utilisateurs { get; } = new List<Utilisateur>();

    public virtual ICollection<Permission> IdPermissions { get; } = new List<Permission>();
}
