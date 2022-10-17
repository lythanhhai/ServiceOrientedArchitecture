using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Test.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Category { get; set; }

        // public DbSet<Student> Students { get; set; }

        // public DbSet<Course> Courses { get; set; }

        // public DbSet<StudentCourse> StudentCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.Category)
            //     .WithOne(c => c.Products)

            // modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            // modelBuilder.Entity<StudentCourse>()
            //     .HasOne(sc => sc.Students)
            //     .WithMany(s => s.StudentCourses)
            //     .HasForeignKey(sc => sc.StudentId);


            // modelBuilder.Entity<StudentCourse>()
            //     .HasOne(sc => sc.Courses)
            //     .WithMany(s => s.StudentCourses)
            //     .HasForeignKey(sc => sc.CourseId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
