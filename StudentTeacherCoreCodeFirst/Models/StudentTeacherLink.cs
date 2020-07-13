using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTeacherCore.Models
{
    public class StudentTeacherLink
    {
        public int studentid { get; set; }
        public Student student { get; set; }
        public int teacherid { get; set; }
        public Teacher teacher { get; set; }
    }
}
