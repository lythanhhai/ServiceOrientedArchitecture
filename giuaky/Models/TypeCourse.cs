using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using giuaky.Models;

namespace giuaky.Models
{
    public class TypeCourse
    {
        // public Category()
        // {
        //     Products = new List<Product>();
        // }
        public int Id { get; set; }
 
        public string Name { get; set; }
 
        public List<Course> Courses { get; set; }
    }
}
