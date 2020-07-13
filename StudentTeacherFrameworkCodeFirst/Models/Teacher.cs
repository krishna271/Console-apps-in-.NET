using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherFramework.Models
{
    class Teacher
    {
        public int teacherid { get; set; }
        public string name { get; set; }
        public string subject { get; set; }
        public List<StudentTeacherLink> StudentTeachers { get; set; }
    }
}
