using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Controllers
{
    public class CoursesListController : Controller
    {
        ICourseService _courseService;

        public CoursesListController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var result = new List<CourseViewModel>();
            var courses = await _courseService.GetAll();
            foreach (var course in courses)
            {
                var item = new CourseViewModel() { Id = course.Id, Name = course.Name, Discription = course.Discription };
                result.Add(item);
            }

            return View(result);
        }

        public async Task<IActionResult> AddCourse()
        {
            return Content("Ещё не сделано(");

        }


    }
}
