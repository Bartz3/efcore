#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using efcore;
using efcore.Models;

namespace efcore.Data
{
    public class UniversityContext : DbContext
    {
        public UniversityContext (DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }
        public DbSet<efcore.Models.Faculty> Faculty { get; set; }
        public DbSet<efcore.Models.Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Faculty>().ToTable("Faculty");
        }



    }
}
