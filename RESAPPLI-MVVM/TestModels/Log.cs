using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class Log
{
    public int Id { get; set; }

    public DateTime? Date { get; set; }

    public int? UtilisateurId { get; set; }

    public string? Action { get; set; }

    public string? Contenu { get; set; }

    public virtual Utilisateur? Utilisateur { get; set; }
}
