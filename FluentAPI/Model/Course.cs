using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI.Model
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double FullPrice { get; set; }

        public CourseLevel Level { get; set; }

        public virtual ICollection<Utilisateur> Users { get; set; }

        public virtual Author Author { get; set; } //propriété de navigation

        public int? AuthorId { get; set; }  //int? ce champs peut accepter des valeurs null

    }

    public enum CourseLevel
    {
        BEGGINNER = 1,
        INERMEDIATE, 
        ADVANCED 
    }
}
