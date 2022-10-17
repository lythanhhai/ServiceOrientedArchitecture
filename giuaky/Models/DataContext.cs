using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using giuaky.Models;

namespace giuaky.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }

        public DbSet<TypeCourse> TypeCourse { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>()
                .HasOne(c => c.TypeCourse)
                .WithMany(tc => tc.Courses)
                .HasForeignKey(c => c.TypeCourseId);

            base.OnModelCreating(builder);

        }
    }
}