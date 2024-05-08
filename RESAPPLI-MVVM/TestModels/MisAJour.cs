using System;
using System.Collections.Generic;

namespace RESAPPLI_MVVM.TestModels;

public partial class MisAJour
{
    public int Id { get; set; }

    public DateTime? DtCreate { get; set; }

    public string? Titre { get; set; }

    public string? Contenu { get; set; }

    public string? Auteur { get; set; }
}
