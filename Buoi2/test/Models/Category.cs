using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Test.Models
{
    public class Category
    {
        // public Category()
        // {
        //     Products = new List<Product>();
        // }
        public int Id { get; set; }
 
        public string Name { get; set; }
 
        public List<Product> Products { get; set; }
    }
}
