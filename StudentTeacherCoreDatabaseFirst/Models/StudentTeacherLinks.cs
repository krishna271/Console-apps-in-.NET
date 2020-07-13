using System;
using System.Collections.Generic;

namespace StudentTeacherCoreDatabaseFirst.Models
{
    public partial class StudentTeacherLinks
    {
        public int Studentid { get; set; }
        public int Teacherid { get; set; }

        public virtual Students Student { get; set; }
        public virtual Teachers Teacher { get; set; }
    }
}
