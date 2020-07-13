using StudentTeacherFrameworkDatabaseFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacherFrameworkDatabaseFirst
{
    class Program
    {
        public Schooldb2Entities db;
        public Program() { }
        public Program(Schooldb2Entities dbc)
        {
            db = dbc;
        }
        public void addStudent(string name)
        {
            Student student = new Student() { Name = name };
            db.Students.Add(student);
            db.SaveChanges();
            Console.WriteLine("added student");
        }
        public void updateStudent(int id, string name)
        {
            Student student = new Student() { Studentid = id, Name = name };
            db.Students.AddOrUpdate(student);
            db.SaveChanges();
            Console.WriteLine("updated student");
        }
        public void deleteStudent(int id)
        {
            Student student = new Student() { Studentid = id };
            db.Students.Remove(student);
            db.SaveChanges();
            Console.WriteLine("deleted student");
        }
        public void printAllStudents()
        {
            Student[] students = db.Students.ToArray();
            foreach (var student in students)
            {
                Console.WriteLine("\nId: {0}\tName: {1}", student.Studentid, student.Name);
            }
        }
        public void addTeacher(string name, string subject)
        {
            Teacher teacher = new Teacher() { Name = name, Subject = subject };
            db.Teachers.Add(teacher);
            db.SaveChanges();
            Console.WriteLine("added teacher");
        }
        public void updateTeacher(int id, string name, string subject)
        {
            Teacher teacher = new Teacher() { Teacherid = id, Name = name, Subject = subject };
            db.Teachers.AddOrUpdate(teacher);
            db.SaveChanges();
            Console.WriteLine("updated teacher");
        }
        public void deleteTeacher(int id)
        {
            Teacher teacher = new Teacher() { Teacherid = id };
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            Console.WriteLine("deleted teacher");
        }
        public void printAllTeachers()
        {
            Teacher[] teachers = db.Teachers.ToArray();
            foreach (var teacher in teachers)
            {
                Console.WriteLine("\nId: {0}\tName: {1}\tSubject: {2}", teacher.Teacherid, teacher.Name, teacher.Subject);
            }
        }
        public void addrelations(int studentid, List<int> teacherids)
        {
            foreach (var id in teacherids)
            {
                Teacher link = db.Teachers.FirstOrDefault(x => x.Teacherid == id);
                db.Students.FirstOrDefault(x => x.Studentid == studentid).Teachers.Add(link);
                db.SaveChanges();
            }
            Console.WriteLine("\nRelations added");
        }
        public void deleterelation(int studentid, int teacherid)
        {
            Teacher link = db.Teachers.FirstOrDefault(x => x.Teacherid == teacherid);
            db.Students.FirstOrDefault(x => x.Studentid == studentid).Teachers.Remove(link);
            db.SaveChanges();
            Console.WriteLine("\nRelation deleted");
        }
        static void Main(string[] args)
        {
            Program p = new Program(new Schooldb2Entities());
            bool flag = true;
            int id;
            string name, subject;
            while (flag)
            {
                Console.WriteLine("\nChoose operation\n1.Add student\n2.Update student\n3.Delete student\n4.Print all students\n5.Add teacher\n6.Update teacher\n7.Delete teacher\n8.Print all teachers\n9.Add relation between student and teachers\n10.Delete relation\n");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("\nEnter student name: ");
                        name = Console.ReadLine();
                        p.addStudent(name);
                        break;
                    case 2:
                        Console.Write("\nEnter student id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nEnter student new name: ");
                        name = Console.ReadLine();
                        p.updateStudent(id, name);
                        break;
                    case 3:
                        Console.Write("\nEnter student id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        p.deleteStudent(id);
                        break;
                    case 4:
                        p.printAllStudents();
                        break;
                    case 5:
                        Console.Write("\nEnter teacher name: ");
                        name = Console.ReadLine();
                        Console.Write("\nEnter subject: ");
                        subject = Console.ReadLine();
                        p.addTeacher(name, subject);
                        break;
                    case 6:
                        Console.Write("\nEnter teacher id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nEnter new teacher name: ");
                        name = Console.ReadLine();
                        Console.Write("\nEnter new subject: ");
                        subject = Console.ReadLine();
                        p.updateTeacher(id, name, subject);
                        break;
                    case 7:
                        Console.Write("\nEnter teacher id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        p.deleteTeacher(id);
                        break;
                    case 8:
                        p.printAllTeachers();
                        break;
                    case 9:
                        Console.Write("\nEnter student id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nEnter teacherids space seperated: ");
                        string[] teacherids = Console.ReadLine().Split(' ');
                        List<int> teacherids_list = new List<int>();
                        foreach (var teacherid in teacherids)
                        {
                            teacherids_list.Add(Convert.ToInt32(teacherid));
                        }
                        p.addrelations(id, teacherids_list);
                        break;
                    case 10:
                        Console.Write("\nEnter student id: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nEnter teacher id: ");
                        int id1 = Convert.ToInt32(Console.ReadLine());
                        p.deleterelation(id, id1);
                        break;
                    default:
                        Console.WriteLine("\nEntered wrong option\n");
                        break;
                }
                Console.WriteLine("\nEnter Y if you want to continue: ");
                char flag1 = Convert.ToChar(Console.ReadLine());
                Console.Clear();
                if (flag1 == 'Y' || flag1 == 'y')
                {
                    continue;
                }
                else
                {
                    flag = false;
                }
            }
        }
    }
}
