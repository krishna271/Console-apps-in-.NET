using System;
using System.Collections.Generic;

namespace StudentTeacherCoreDatabaseFirst.Models
{
    public partial class Teachers
    {
        public Teachers()
        {
            StudentTeacherLinks = new HashSet<StudentTeacherLinks>();
        }

        public int Teacherid { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }

        public virtual ICollection<StudentTeacherLinks> StudentTeacherLinks { get; set; }
    }
}
