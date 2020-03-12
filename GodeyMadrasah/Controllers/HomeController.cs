using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodeyMadrasah.Models;
using Microsoft.AspNetCore.Mvc;

namespace GodeyMadrasah.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolDatabase Context;
        public HomeController(SchoolDatabase context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            ViewBag.NumOfStudents = Context.Students.Count();
            ViewBag.NumOfCourses = Context.Subjects.Count();
            ViewBag.NumOfTeachers = Context.Teachers.Count();
           
            return View();
        }

    }
}