using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherFramework.Models
{
    class Student
    {
        public int studentid { get; set; }
        public string name { get; set; }
        public List<StudentTeacherLink> StudentTeachers { get; set; }
    }
}
