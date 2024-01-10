using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESAPPLI_MVVM.Models
{
    [Table("utilisateur")]
    public class Utilisateur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        [Column("CREATE_AT")]
        public DateTime CreateAt { get; set; }

        [Column("LAST_CO")]
        public DateTime LastConnection { get; set; }

        [ForeignKey("TypeCompte")]
        [Column("ID_TypeCompte")]
        public int TypeCompteId { get; set; }
        public TypeCompte TypeCompte { get; set; }

        [ForeignKey("Entreprise")]
        [Column("ID_Entreprise")]
        public int? EntrepriseId { get; set; }
        public Entreprise Entreprise { get; set; }
    }

}