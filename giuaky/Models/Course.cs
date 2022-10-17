using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using giuaky.Models;

namespace giuaky.Models
{
    // [Table("Product")]
    public class Course
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Slug { get; set; }

        public int TypeCourseId { get; set; }

        public TypeCourse TypeCourse { get; set; }

        [MaxLength(512)]
        public string Overall { get; set; }
        [MaxLength(1024)]
        public string? Content { get; set; }
        [MaxLength(256)]
        public string Image { get; set; }

        // // [Required]
        // public string Option { get; set; }
    }
}