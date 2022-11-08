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

        public int NumVoie { get; set; }

        public string CodePostale { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }
    }
}
