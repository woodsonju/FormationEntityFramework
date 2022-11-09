using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Model
{
    [Table("t_Course")]
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Column("CoursDescription")]
        [MaxLength(2000)]
        public string Description { get; set; }

        public double FullPrice { get; set; }

        public CourseLevel Level { get; set; }

        public virtual ICollection<Utilisateur> Users { get; set; }

        //Définir une propriété de navigation
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        //La propriété AuthorId est une clé étrangère 
        //et la propriété de navigation correspondante est Author
        public int? AuthorId { get; set; }  //int? ce champs peut accepter des valeurs null

    }

    public enum CourseLevel
    {
        BEGGINNER = 1,
        INERMEDIATE, 
        ADVANCED 
    }
}
