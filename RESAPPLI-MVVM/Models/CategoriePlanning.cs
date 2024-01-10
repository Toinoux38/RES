using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESAPPLI_MVVM.Models
{
    [Table("categorieplanning")]
    public class CategoriePlanning
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
    }
}