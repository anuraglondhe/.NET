using System;

namespace PartA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>()
            {
                new Book{Id=1, Title="Chhava", Author="Shivaji Sawant", Price=150},
                new Book{Id=2, Title="Agnipankh", Author="APJ Abdul Kalam", Price=250},
                new Book{Id=3, Title="Mrutyunjay", Author="Shivaji Sawant", Price=300},
                new Book{Id=4, Title="Yayati", Author="V.S. Khandekar", Price=220},

                new Book{Id=5, Title="Wings of Fire", Author="John Bell", Price=280},

                new Book{Id=6, Title="Panipat", Author="Vishwas Patil", Price=260},

                new Book{Id=7, Title="Shriman Yogi", Author="Eric Stone", Price=350},

                new Book{Id=8, Title="Kosala", Author="B. Nemide", Price=200},
                new Book{Id=9, Title="Pather Panchali", Author="S. D’Cruz", Price=180},
                new Book{Id=10, Title="The Alchemist", Author="Paulo Coelho", Price=320}
            };



            var result = books.OrderBy(b => b.Price);


            foreach (var b in result)
            {
                Console.WriteLine($"{b.Id}  {b.Title}  {b.Author}  {b.Price}");
            }

            Console.WriteLine("\nBooks where Author name contains 'a':");

            foreach (Book b in books)
            {
                if (b.Author.ToLower().Contains("a"))
                {
                    Console.WriteLine($"{b.Id}  {b.Title}  {b.Author}  {b.Price}");
                }
            }

            Console.WriteLine("Enter the Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            foreach (Book b in books)
            {
                if (b.Id == Id)
                {
                    books.Remove(b);
                    break;
                }
            }

            foreach (Book b in books)
            {

                Console.WriteLine($"{b.Id} {b.Title} {b.Author} {b.Price}");
            }



            Dictionary<int, string> students = new Dictionary<int, string>()
        {
            {1,"Rohan"},
            {2,"Soham"},
            {3,"Aniket"},
            {4,"Neha"},
            {5,"Priya"},
            {6,"Vikram"}
        };

            Console.Write("Enter roll number to search: ");
            int roll = Convert.ToInt32(Console.ReadLine());

            if (students.ContainsKey(roll))
            {
                Console.WriteLine("Student Name: " + students[roll]);
            }
            else
            {
                Console.WriteLine("Roll number not found.");
            }

            var result2 = students.OrderBy(x => x.Value);

            foreach(var s in result2)
            {
                Console.WriteLine($"{s.Key} {s.Value}");
            }

        }
        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public double Price { get; set; }


        }


        class Student
        {
            public int RollNo { get; set; }
            public string StuName { get; set; }
        }
    }

}
