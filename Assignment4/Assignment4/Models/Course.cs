using System;

namespace Assignment4.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public String CourseName { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}

