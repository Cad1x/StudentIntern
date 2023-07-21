using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class StudentAppContext : DbContext
    {
        public StudentAppContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Student

            modelBuilder.Entity<Student>().ToTable("Students");
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
            .Property(s => s.DateOfBirth)
            .HasConversion(
                  v => v.ToDateTime(TimeOnly.MinValue),
                  v => DateOnly.FromDateTime(v)
            );

            modelBuilder.Entity<Student>()
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.Email)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.DateOfBirth)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(p => p.StudyStartYear)
                .IsRequired();




            #endregion
        }
    }
}
