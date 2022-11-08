using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Model
{
    public class Course
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double FullPrice { get; set; }

        public CourseLevel Level { get; set; }

        public virtual ICollection<Utilisateur> Users { get; set; }

        //Définir une propriété de navigation
        public virtual Author Author { get; set; }

        //La propriété AuthorId est une clé étrangère 
        public int AuthorId { get; set; }

    }

    public enum CourseLevel
    {
        BEGGINNER = 1,
        INERMEDIATE, 
        ADVANCED 
    }
}
