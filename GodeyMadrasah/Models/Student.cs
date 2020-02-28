using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodeyMadrasah.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(6)]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public int? SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
