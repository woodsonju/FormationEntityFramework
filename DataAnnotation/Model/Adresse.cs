using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Model
{
    public class Adresse
    {
        [Key]
        public int AdrId { get; set; }

        [Required]
        public string NomDeVoie { get; set; }

        [Required]
        [Range(1, 1000)]
        public int NumVoie { get; set; }

        [Required, DataType(DataType.PostalCode)] 
        public string CodePostale { get; set; }

        [Required]
        public string Ville { get; set; }

        [Required]
        public string Pays { get; set; }
    }
}
