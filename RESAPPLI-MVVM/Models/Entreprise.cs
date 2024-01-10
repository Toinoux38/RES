using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESAPPLI_MVVM.Models
{
    [Table("entreprise")] // Spécifie le nom de la table dans la base de données
    public class Entreprise
    {
        [Key]
        public int ID { get; set; }

        // Autres propriétés de l'entreprise
        public string Nom { get; set; }
        public DateTime DateCreation { get; set; }

        // Autres propriétés...
    }
}