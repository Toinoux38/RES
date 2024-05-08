using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Permission
{
    public int Id { get; set; }

    public string? Libelle { get; set; }

    public virtual ICollection<Typecompte> IdTypeComptes { get; } = new List<Typecompte>();
}
