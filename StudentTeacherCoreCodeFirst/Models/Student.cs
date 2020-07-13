using System;
using System.Collections.Generic;
using System.Text;

namespace StudentTeacherCore.Models
{
    public class Student
    {
        public int studentid { get; set; }
        public string name { get; set; }
        public List<StudentTeacherLink> StudentTeachers { get; set; }
    }
}
