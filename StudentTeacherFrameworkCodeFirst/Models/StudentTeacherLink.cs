using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherFramework.Models
{
    class StudentTeacherLink
    {
        public int studentid { get; set; }
        public Student student { get; set; }
        public int teacherid { get; set; }
        public Teacher teacher { get; set; }
    }
}
