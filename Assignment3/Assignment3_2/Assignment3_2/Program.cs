using Microsoft.EntityFrameworkCore;
using System;
namespace Assignment3_2
{
    public class Program
    {
        static TaskContext tc = new TaskContext();

        public static void Main(string[] args)
        {
            int choice;            
            do{
                Console.WriteLine("1. Add Manager \n2. Add Staff (assign to Manager) \n3. Add Task \r\n(assign to Staff) \n4. View all Managers, Staff & Tasks \n5. Update Task (mark as completed) \n6.Delete Task \n7. Exit ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddManager();
                        break;
                    case 2:
                        AddStaff();
                        break;
                    case 3:
                        AddTask();
                        break;
                    case 4:
                        Display();
                        break;
                    case 5:
                        UpdateTask();
                        break;
                    case 6:
                        DeleteTask();
                        break;
                }

            } while (choice != 7);
        }

        public static int AddManager()
        {
            Manager mg = new Manager();

            Console.WriteLine("Manager Name: ");
            mg.Name= Console.ReadLine();

            Console.WriteLine("Manager's Email:");
            mg.Email = Console.ReadLine();

            tc.Managers.Add(mg);
            return tc.SaveChanges();
            
        }
        public static int AddStaff()
        {
            Staff staff = new Staff();

            Console.WriteLine("Staff's Name: ");
            staff.Name = Console.ReadLine();

            Console.WriteLine("Staff's Email: ");
            staff.Email = Console.ReadLine();

            Console.WriteLine("Manager's Id: ");
            staff.ManagerId = Convert.ToInt32(Console.ReadLine());

            tc.Staffs.Add(staff);
            return tc.SaveChanges();

        }
        public static int AddTask()
        {

            TaskItem task = new TaskItem();

            //title
            Console.WriteLine("Title: ");
            task.Title = Console.ReadLine();

            //description
            Console.WriteLine("Description: ");
            task.Description = Console.ReadLine();

            //IsCompleted
            Console.WriteLine("Is Completed: ");
            task.IsCompleted = Convert.ToBoolean(Console.ReadLine());

            //StaffId
            Console.WriteLine("Staff Id: ");
            task.StaffId = Convert.ToInt32(Console.ReadLine());

            tc.TaskItems.Add(task);
            return tc.SaveChanges();
        }
        public static void Display()
        {
            List<Manager> m = GetAllManagers();
            foreach (var mgr in m)
            {
                Console.WriteLine($"Manager id: {mgr.ManagerId}  Name: {mgr.Name}  Email: {mgr.Email}");
                foreach (var stf in mgr.Staffs)
                {
                    Console.WriteLine($"  - Staff id: {stf.StaffId}  Name: {stf.Name}  Email: {stf.Email}");
                    foreach (var tsk in stf.Tasks)
                    {
                        Console.WriteLine($"    - Task id: {tsk.TaskItemId}  Title: {tsk.Title}  Discription: {tsk.Description}  Is Completed: {tsk.IsCompleted}");
                    }
                }
                Console.WriteLine();
            }
        }
        public static int UpdateTask()
        {
                 
            TaskItem tsk = new TaskItem();
            tsk = FindTask();
            tsk.IsCompleted = true;
            return tc.SaveChanges();

        }
        public static int DeleteTask()
        {
             tc.TaskItems.Remove(FindTask());
            return tc.SaveChanges();

        }

        public static TaskItem FindTask()
        {
            Console.WriteLine("Enter Task Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            return tc.TaskItems.Find(Id);
        }
        public static List<Manager> GetAllManagers()
        {
            return tc.Managers.Include(s => s.Staffs).ThenInclude(st => st.Tasks).ToList();
        }

    }
}
