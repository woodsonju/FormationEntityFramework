using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotation.Model
{
    public class Author
    {
        [Key]
        public int AuthId { get; set; }

        [Required]
        [MaxLength(50), MinLength(1)]
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
