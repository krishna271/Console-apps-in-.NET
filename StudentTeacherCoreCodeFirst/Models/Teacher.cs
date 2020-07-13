using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTeacherCore.Models
{
    public class Teacher
    {
        public int teacherid { get; set; }
        public string name { get; set; }
        public string subject { get; set; }
        public List<StudentTeacherLink> StudentTeachers { get; set; }
    }
}
