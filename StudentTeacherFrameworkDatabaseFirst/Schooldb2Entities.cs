namespace StudentTeacherFrameworkDatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Schooldb2Entities : DbContext
    {
        internal readonly object StudentTeacherLinks;

        public Schooldb2Entities()
            : base("name=Schooldb2Entities")
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.Students)
                .Map(m => m.ToTable("StudentTeacherLinks").MapLeftKey("studentid").MapRightKey("teacherid"));
        }
    }
}
