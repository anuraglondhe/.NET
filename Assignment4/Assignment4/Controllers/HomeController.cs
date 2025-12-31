using System.Diagnostics;
using Assignment4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4.Controllers
{
    public class HomeController : Controller
    {
        Spcontext sp = new Spcontext();

        public IActionResult Index()
        {

            List<Student> slist = sp.Student.ToList();

            return View("Index", slist);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AfterCreate(Student s)
        {
            Student std = new Student();
            std.FirstName = s.FirstName; 
            std.LastName =s.LastName;
            sp.Student.Add(std);
            sp.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult Edit()
        {
            Student s1 = sp.Student.Find(id);
            return View(s1);
        }

        public IActionResult AfterEdit()
        {
             Student s1 = sp.Student.Find(s, id);
            s1.FirstName = sp.FirstName;
            s1.LastName = sp.CourseName;
            sp.SaveChanges();
            return Redirect("/Home/Index");
        }
        public IActionResult Delete(int id)
        {

            Student s1 = sp.Student.Find(id);
            sp.Student.Remove(s1);
            sp.SaveChanges();
            return Redirect("/Home/Index");
        }



    }
}
