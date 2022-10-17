using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using giuaky.Models;
using giuaky.Services;
using giuaky.DTOs;

namespace giuaky.Controllers
{
    public class CourseController : Controller
    {

        private readonly ICourseService _courseService;

        public CourseController(ICourseService iCourseService)
        {
            
            _courseService = iCourseService;
        }

        public IActionResult Index()
        {
            var courses = _courseService.GetCourses();
            ViewBag.typeCourses = _courseService.GetTypeCourses();
            return View(courses);
        }

        public IActionResult Create()
        {
            var typeCourse = _courseService.GetTypeCourses();
            return View(typeCourse);
        }

        public IActionResult Update(int Id)
        {
            var course = _courseService.GetCourseById(Id);
            if (course == null) return RedirectToAction("Create");
            var typeCourses = _courseService.GetTypeCourses();
            ViewBag.Course = course;
            return View(typeCourses);
        }

        public IActionResult Save(Course course)
        {
            List<Course> listCourse = _courseService.GetCourses();
            var check = 0;
            foreach(var course1 in listCourse)
            {
                if(course1.Id == course.Id)
                {
                    check = 1;
                    break;
                }
            }
            if (check == 0)
            {
                _courseService.CreateCourse(course);
            }
            else
            {
                _courseService.UpdateCourse(course);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _courseService.DeleteCourse(Id);
            return RedirectToAction("Index");
        }

        public IActionResult Search(SearchObject Data)
        {
            // Console.WriteLine(Data);
            var listCourse = _courseService.GetCoursesBySearch(Data);
            ViewBag.typeCourses = _courseService.GetTypeCourses();
            return View(listCourse);
        }

        public IActionResult Sort(Sort Data)
        {
            // Console.WriteLine(Data);
            var listCourse = _courseService.Sort(Data);
            ViewBag.typeCourses = _courseService.GetTypeCourses();
            return View(listCourse);
        }
    }
}