using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Assignment4.Models
{
    public class Spcontext : DbContext
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =(LocalDB)\\MSSQLLocalDB;Database=Assign4;Trusted_Connection =True;");
        }
    }
}
