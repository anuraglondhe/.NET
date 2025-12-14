using Microsoft.EntityFrameworkCore;

namespace Assignment3_2
{
   
        public class TaskContext : DbContext
        {
            public DbSet<Manager> Managers {  get; set; }
            public DbSet<Staff> Staffs { get; set; }
            public DbSet<TaskItem> TaskItems { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=TaskManagementDB;Trusted_Connection=True");
            }
        }
        
    
}
