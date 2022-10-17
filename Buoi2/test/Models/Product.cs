using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    // [Table("Product")]
    public class Product
    {
        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Slug { get; set; }

        public int Price { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
    
        public Category Category { get; set; }

        // [Required]
        public string Option { get; set; }
    }
}