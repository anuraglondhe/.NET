namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Roll Number: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your course name: ");
            string course = Console.ReadLine();
        }
       
    }
}
