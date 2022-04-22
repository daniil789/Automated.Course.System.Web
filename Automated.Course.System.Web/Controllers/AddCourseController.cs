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
    public class AddCourseController : Controller
    {
        private readonly ILanguageService _languageService;
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public AddCourseController(ILanguageService languageService, IMapper mapper, ICourseService courseService)
        {
            _languageService = languageService;
            _courseService = courseService;
            _mapper = mapper;
        }


        [Authorize(Roles = "teacher")]
        [HttpGet]
        public IActionResult AddCourse()
        {
            var vm = new AddCourseViewModel();


            foreach (var item in _languageService.GetAll())
            {
                vm.Languages.Add(_mapper.Map<LanguageViewModel>(item));
            }

            return View(vm);
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
