using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment4.Models
{
    public class Student
    {
        [Key]
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }


            public List<Course> Courses { get; set; }
            public Course Course { get; set; }

    }

}

