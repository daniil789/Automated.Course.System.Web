using AutoMapper;
using Automated.Course.System.BLL.DTO;
using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.DAL.Entities;
using Automated.Course.System.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly UserManager<User> _userManager;
        private readonly IServiceProvider _serviceProvider;
        private readonly IChapterService _chapterService;
        private readonly ITaskService _taskService;

        private EditCourseViewModel editVm { get; set; }

        public CoursesListController(ICourseService courseService, IMapper mapper, ILanguageService languageService, UserManager<User> userManager,
            IServiceProvider serviceProvider, IChapterService chapterService, ITaskService taskService)
        {
            _courseService = courseService;
            _mapper = mapper;
            _languageService = languageService;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
            _chapterService = chapterService;
            _taskService = taskService;
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

        [HttpGet]
        public IActionResult AddCourse()
        {
            var languages = new List<LanguageViewModel>();
            var addCourseVM = new EditCourseViewModel();
            var languagesDTO = _languageService.GetAll();
            foreach(var language in languagesDTO)
            {
                languages.Add(_mapper.Map<LanguageViewModel>(language));
            }

            addCourseVM.Languages = languages;

            return View(addCourseVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(CourseViewModel course)
        {
            //var curUser = await _userManager.FindByNameAsync(User.Identity.Name);

            //var course = new CourseDTO() { Name = name, Discription = description, LanguageId = language, CreateUserId = curUser.Id };

            //await _courseService.CreateCourse(course);

            return RedirectToAction("MyCourses", "CoursesList");
        }
    }
}
