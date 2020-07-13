using System;
using System.Collections.Generic;

namespace StudentTeacherCoreDatabaseFirst.Models
{
    public partial class Students
    {
        public Students()
        {
            StudentTeacherLinks = new HashSet<StudentTeacherLinks>();
        }

        public int Studentid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentTeacherLinks> StudentTeacherLinks { get; set; }
    }
}
