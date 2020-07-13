using StudentTeacherFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentTeacherFramework
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=dbcs")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTeacherLink>()
                .HasKey(t => new { t.studentid, t.teacherid });
             
            modelBuilder.Entity<StudentTeacherLink>()
                .HasRequired(pt => pt.student)
                .WithMany(p => p.StudentTeachers)
                .HasForeignKey(pt => pt.studentid);

            modelBuilder.Entity<StudentTeacherLink>()
                .HasRequired(pt => pt.teacher)
                .WithMany(t => t.StudentTeachers)
                .HasForeignKey(pt => pt.teacherid);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentTeacherLink> StudentTeacherLinks { get; set; }
    }
}
