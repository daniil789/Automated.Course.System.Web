using AutoMapper;
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
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;
        private readonly ILanguageService _languageService;

        public CoursesListController(ICourseService courseService, IMapper mapper, ILanguageService languageService )
        {
            _courseService = courseService;
            _mapper = mapper;
            _languageService = languageService;
        }

        public async Task<IActionResult> Index()
        {
            var result = new List<CourseViewModel>();
            var courses = await _courseService.GetAll();
            foreach (var course in courses)
            {

                result.Add(new CourseViewModel { Name = course.Name, Discription = course.Discription, Language = _languageService.GetLanguageById(course.LanguageId).LanguageName });
            }

            return View(result);
        }

        public async Task<IActionResult> AddCourse()
        {
            return Content("Ещё не сделано(");

        }


    }
}
