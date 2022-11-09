using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Model
{
    public class Utilisateur
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateNaissance { get; set; }

        public TypeUtilisateur TypeUtilisateur { get; set; }

        public int AdresseId { get; set; }

        public virtual Adresse Adresse { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
