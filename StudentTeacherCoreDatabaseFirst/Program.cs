using StudentTeacherCoreDatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentTeacherCore
{
    public class Program
    {
        public Schooldb2Context db;
        public Program() { }
        public Program(Schooldb2Context dbc)
        {
            db = dbc;
        }
        public void addStudent(string name)
        {
            Students student = new Students() { Name = name };
            db.Students.Add(student);
            db.SaveChanges();
            Console.WriteLine("added student");
        }
        public void updateStudent(int id, string name)
        {
            Students student = new Students() { Studentid = id, Name = name };
            db.Students.Update(student);
            db.SaveChanges();
            Console.WriteLine("updated student");
        }
        public void deleteStudent(int id)
        {
            Students student = new Students() { Studentid = id };
            db.Students.Remove(student);
            db.SaveChanges();
            Console.WriteLine("deleted student");
        }
        public void printAllStudents()
        {
            Students[] students = db.Students.ToArray();
            foreach (var student in students)
            {
                Console.WriteLine("\nId: {0}\tName: {1}", student.Studentid, student.Name);
            }
        }
        public void addTeacher(string name, string subject)
        {
            Teachers teacher = new Teachers() { Name = name, Subject = subject };
            db.Teachers.Add(teacher);
            db.SaveChanges();
            Console.WriteLine("added teacher");
        }
        public void updateTeacher(int id, string name, string subject)
        {
            Teachers teacher = new Teachers() { Teacherid = id, Name = name, Subject = subject };
            db.Teachers.Update(teacher);
            db.SaveChanges();
            Console.WriteLine("updated teacher");
        }
        public void deleteTeacher(int id)
        {
            Teachers teacher = new Teachers() { Teacherid = id };
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            Console.WriteLine("deleted teacher");
        }
        public void printAllTeachers()
        {
            Teachers[] teachers = db.Teachers.ToArray();
            foreach (var teacher in teachers)
            {
                Console.WriteLine("\nId: {0}\tName: {1}\tSubject: {2}", teacher.Teacherid, teacher.Name, teacher.Subject);
            }
        }
        public void addrelations(int studentid, List<int> teacherids)
        {
            foreach (var id in teacherids)
            {
                StudentTeacherLinks link = new StudentTeacherLinks() { Studentid = studentid, Teacherid = id };
                db.StudentTeacherLinks.Add(link);
                db.SaveChanges();
            }
            Console.WriteLine("\nRelations added");
        }
        public void deleterelation(int studentid, int teacherid)
        {
            StudentTeacherLinks link = new StudentTeacherLinks() { Studentid = studentid, Teacherid = teacherid };
            db.StudentTeacherLinks.Remove(link);
            db.SaveChanges();
            Console.WriteLine("\nRelation deleted");
        }
        static void Main(string[] args)
        {
            Program p = new Program(new Schooldb2Context());
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
