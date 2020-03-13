using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodeyMadrasah.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GodeyMadrasah.Controllers
{
    public class StudentsController : Controller
    {

        public StudentsController(SchoolDatabase database)
        {
            Database = database;
        }

        public SchoolDatabase Database { get; }

        public IActionResult AllStudents()
        {
            var students = Database.Students.Include(t => t.Teacher).Include( s => s.Subject).ToList();
            return View(students);
        }

        public IActionResult CreateStudent()
        {
            ViewData["Courses"] = Database.Subjects.ToList();
            ViewData["Teachers"] = Database.Teachers.ToList();

            return View();
        }


        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Database.Students.Add(student);
                Database.SaveChanges();
                return RedirectToAction("AllStudents");
            }

            ViewData["Courses"] = Database.Subjects.ToList();
            ViewData["Teachers"] = Database.Teachers.ToList();

            return View(student);
        }

        public IActionResult  EditStudent(int Id)
        {
            var student = Database.Students.Find(Id);
            if(student  == null)
            {
                return NotFound("Student Not Found");
            }
            ViewData["Courses"] = Database.Subjects.ToList();
            ViewData["Teachers"] = Database.Teachers.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                Database.Students.Update(student);
                Database.SaveChanges();
                return RedirectToAction("AllStudents");
            }

            ViewData["Courses"] = Database.Subjects.ToList();
            ViewData["Teachers"] = Database.Teachers.ToList();

            return View(student);
        }

        public IActionResult DeleteStudent(int Id)
        {
            var student = Database.Students.Find(Id);
            if (student == null)
            {
                return NotFound("Student Not Found");
            }
            Database.Students.Remove(student);
            Database.SaveChanges();
            return RedirectToAction("AllStudents");
        }
    }
}