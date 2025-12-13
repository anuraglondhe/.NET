using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment3_1
{
    internal class Program
    {
        static SchoolContext sc = new SchoolContext();
        static List<Student> stdList;
        static void Main(string[] args)
        {

            int choice;
            do
            {
                Console.WriteLine("1. Add Student\n 2. Add Course (assign to Student)\n 3. View all \r\nStudents with Courses\n 4. Update Course Name\n 5. Delete Course\n 6. Exit ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;

                    case 2:
                        AddCourse();
                        break;
                    case 3:
                        Display();
                        break;
                    case 4:
                        UpdateCourse();
                        break;
                    case 5:
                        DeleteCourse();
                        break;

                }


            } while (choice != 6);


        }

        //1.Add Students
        public static int AddStudent()
        {
            Student s = new Student();

            Console.Write("First Name: ");
            s.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            s.LastName = Console.ReadLine();

            sc.Students.Add(s);
            return sc.SaveChanges();
        }

        public static int AddCourse()
        {
            Course c = new Course();

            Console.Write("Student Id: ");
            c.StudentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Course Name: ");
            c.CourseName = Console.ReadLine();

            sc.Courses.Add(c);
            return sc.SaveChanges();

        }

        public static void Display()
        {
            stdList = GetllStudents();
            foreach (var student in stdList)
            {
                Console.WriteLine($"StudentId:{student.StudentId} First Name:{student.FirstName} Last Name:{student.LastName}");
                Console.WriteLine();
                foreach (var c in student.Courses)
                {
                    Console.WriteLine($"Course Id:{c.CourseId} Course Name:{c.CourseName}");
                }
                Console.WriteLine();
            }
        }

        public static List<Student> GetllStudents()
        {
            return sc.Students.Include(s => s.Courses).ToList();
        }


        public static Course FindCourse()
        {
            Console.WriteLine("Enter course Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            return sc.Courses.Find(Id);

        }

        public static int UpdateCourse()
        {
            Course Course = new Course();
            Course = FindCourse();
            Console.WriteLine("Course Name: ");
            Course.CourseName = Console.ReadLine();
            return sc.SaveChanges();
        }

        public static int DeleteCourse()
        {
            Course course = new Course();
            course = FindCourse();
            sc.Courses.Remove(course);
            return sc.SaveChanges();
            
        }
    }
}
