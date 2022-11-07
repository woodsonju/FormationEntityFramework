using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Model
{
    public class Ville
    {
        public int Id { get; set; }

        public string NomVille { get; set; }
        
        //virtual permet d'utiliser le chargement différé (Lazy loading)
        public virtual ICollection<Client> Clients { get; set; }

         
    }
}

