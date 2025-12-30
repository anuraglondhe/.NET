using System.Transactions;
using System.Xml.Linq;
using static PartB.Program;

namespace PartB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Even Numbers:");
            foreach (int Integer in Integers)
            {
                if (Integer % 2 == 0)
                {
                    Console.Write("\t" + Integer);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Maximum Value:" + Integers.Max());
            Console.WriteLine("Minimum Value:" + Integers.Min());
            Console.WriteLine("Average:" + Integers.Average());

            Console.Write("Greater than 20:");
            var sortedIntegers = Integers
                .Where(i => i > 20)
                .OrderByDescending(i => i)
                .ToList();
            foreach (int Integer in sortedIntegers)
            {
                Console.Write("\t" + Integer);
            }

            //-----------------------***------------------------------//

            //IT Dept Members

            var itEmployees = Employees.Where(e => e.Dept == "IT");

            Console.WriteLine("\nIT Employees:");
            foreach (var emp in itEmployees)
            {
                Console.WriteLine($"{emp.Id} {emp.Name} {emp.Salary}");
            }

            //-----------------------***------------------------------//

            //Highest Salary
            var highSal = Employees
            .OrderByDescending(e => e.Salary)
            .First();
            Console.WriteLine("Employee of highest salary:");

            Console.WriteLine($"{highSal.Name}-{highSal.Salary}");

            //-----------------------***------------------------------//

            //Group Employees by department

            var deptGroups = Employees.GroupBy(e => e.Dept);
            Console.WriteLine("Grouped by Departments:\n");
            foreach (var group in deptGroups)
            {
                Console.WriteLine("Department: " + group.Key);

                foreach (var e in group)
                {
                    Console.WriteLine($"  {e.Name}");
                }
            }

            //-----------------------***------------------------------//

            //Display: Student Name – Subject – Score. 

            var result = Students.Join(
                Marks,
                s => s.Id,
                m => m.StudentId,
                (s, m) => new
                {
                    StudentName = s.Name,
                    Subject = m.Subject,
                    Score = m.Score,
                });

            Console.WriteLine("\nStudent Name- Subject- Score");
            foreach (var r in result)
            {
                Console.WriteLine($"{r.StudentName}- {r.Subject}- {r.Score}");
            }

            //-----------------------***------------------------------//

            //Q.8

            Console.WriteLine("\nCities with starts letter with P:");
            var res = City.Where(c => c.StartsWith("P")&&c.Length>5);
            foreach(var r in res)
            {
                Console.WriteLine(r);
            }

        }

        public static List<int> Integers = new List<int> { 10, 2, 30, 4, 55, 60, 7, 8 };

        public class Employee {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Dept { get; set; }
            public double Salary { get; set; }
        }

        static List<Employee> Employees = new List<Employee>()
            {
                new Employee { Id=1, Name="Anurag", Dept="IT", Salary=50000},
                new Employee { Id = 2, Name = "Rohit", Dept = "HR", Salary = 40000 },
                new Employee { Id = 3, Name = "Sneha", Dept = "IT", Salary = 65000 },
                new Employee { Id = 4, Name = "Amit", Dept = "Finance", Salary = 55000 },
                new Employee { Id = 5, Name = "Neha", Dept = "HR", Salary = 45000 }
            };

        public class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        static List<Student> Students = new List<Student>()
            {
                new Student { Id = 1, Name = "Anurag" },
                new Student { Id = 2, Name = "Rohit" },
                new Student { Id = 3, Name = "Sneha" }
            };

        public class Mark
        {
            public int StudentId { get; set; }
            public string Subject { get; set; }
            public int Score { get; set; }
        }
        static List<Mark> Marks = new List<Mark>()
            {
                 new Mark { StudentId = 1, Subject = "Maths", Score = 80 },
                 new Mark { StudentId = 1, Subject = "Science", Score = 75 },
                 new Mark { StudentId = 2, Subject = "Maths", Score = 60 }
             };

       
        public static List<String> City = new List<String>() { "Pune", "Panaji", "Mumbai", "Delhi", "Pondicherry", "Panjab" };
    }
        
    
}
