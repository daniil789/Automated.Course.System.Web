using AutoMapper;
using Automated.Course.System.BLL.DTO;
using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.Web.Models;
using Microsoft.AspNetCore.Authorization;
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

        public CoursesListController(ICourseService courseService, IMapper mapper, ILanguageService languageService)
        {
            _courseService = courseService;
            _mapper = mapper;
            _languageService = languageService;
        }

        public async Task<IActionResult> MyCourses()
        {
            var languages = new List<LanguageViewModel>();
            var languagesDTO = _languageService.GetAll();

            foreach (var language in languagesDTO)
            {
                languages.Add(_mapper.Map<LanguageViewModel>(language));
            }


            var coursesListVM = new List<CourseViewModel>();
            var coursesDTO = await _courseService.GetAll();

            foreach (var course in coursesDTO)
            {
                coursesListVM.Add(_mapper.Map<CourseViewModel>(course));
            }

            var result = new CoursesListViewModel(coursesListVM, languages);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(string name, string description, int language)
        {
            var course = new CourseDTO() { Name = name, Discription = description, LanguageId = language };

            await _courseService.CreateCourse(course);

            return RedirectToAction("Index", "Home");
        }
    }
}
