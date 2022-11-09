using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Model
{
    public class Adresse
    {
        public int Id { get; set; }

        public string NomDeVoie { get; set; }

        public int NumVoie { get; set; }

        public string CodePostale { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }
    }
}
