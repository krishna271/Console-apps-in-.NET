using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StudentTeacherCore.Models;

namespace StudentTeacherCore
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAP-WIN-1134\\SQLEXPRESS;Initial Catalog=Schooldb;User Id=sadata; Password=password;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTeacherLink>()
                .HasKey(t => new { t.studentid, t.teacherid });

            modelBuilder.Entity<StudentTeacherLink>()
                .HasOne(pt => pt.student)
                .WithMany(p => p.StudentTeachers)
                .HasForeignKey(pt => pt.studentid);

            modelBuilder.Entity<StudentTeacherLink>()
                .HasOne(pt => pt.teacher)
                .WithMany(t => t.StudentTeachers)
                .HasForeignKey(pt => pt.teacherid);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentTeacherLink> StudentTeacherLinks { get; set; }
    }
}
