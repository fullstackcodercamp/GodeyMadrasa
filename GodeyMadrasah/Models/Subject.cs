using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodeyMadrasah.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [MaxLength(25)]
        public string SubjectName { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        public double Cost { get; set; } 

        [Required]
        [MaxLength(50)]
        public string Duration { get; set; }

        [Required]
        public int MaxStudents { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual List<Student> Students { get; set; }
    }
}
