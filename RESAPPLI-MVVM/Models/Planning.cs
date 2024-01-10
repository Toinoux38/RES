using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESAPPLI_MVVM.Models
{
    [Table("planning")]
    public class Planning
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Nom { get; set; }

        [Column("DateCreation")]
        public DateTime DateCreation { get; set; }

        [ForeignKey("Entreprise")]
        [Column("ID_Entreprise")]
        public int ID_Entreprise { get; set; }
        public Entreprise Entreprise { get; set; }

        [ForeignKey("CategoriePlanning")]
        [Column("ID_Categorie")]
        public int ID_Categorie { get; set; }
        public CategoriePlanning CategoriePlanning { get; set; }
    }
}