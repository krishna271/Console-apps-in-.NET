using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudentTeacherCoreDatabaseFirst.Models
{
    public partial class Schooldb2Context : DbContext
    {
        public Schooldb2Context()
        {
        }

        public Schooldb2Context(DbContextOptions<Schooldb2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentTeacherLinks> StudentTeacherLinks { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAP-WIN-1134\\SQLEXPRESS;Initial Catalog=Schooldb2;User Id=sadata; Password=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentTeacherLinks>(entity =>
            {
                entity.HasKey(e => new { e.Studentid, e.Teacherid });

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Teacherid).HasColumnName("teacherid");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTeacherLinks)
                    .HasForeignKey(d => d.Studentid)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.StudentTeacherLinks)
                    .HasForeignKey(d => d.Teacherid)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.Studentid);

                entity.Property(e => e.Studentid).HasColumnName("studentid");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.Teacherid);

                entity.Property(e => e.Teacherid).HasColumnName("teacherid");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Subject).HasColumnName("subject");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
