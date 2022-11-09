using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Model
{
    public class Utilisateur
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50), MinLength(1)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50), MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]  //DataType est une annotation utilisée pour l'interface utilisateur 
        public string PhoneNumber { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
       // [Display(Name ="Adresse e-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
      //  [Display(Name ="Mot de passe")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

        public TypeUtilisateur TypeUtilisateur { get; set; }

        public int AdresseId { get; set; }

        [ForeignKey("AdresseId")]
        public virtual Adresse Adresse { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
