using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RESAPPLI_MVVM.Models
{
    public class TypeCompte
    {
        [Key]
        public int ID { get; set; }

        public string Libelle { get; set; }
    }
}