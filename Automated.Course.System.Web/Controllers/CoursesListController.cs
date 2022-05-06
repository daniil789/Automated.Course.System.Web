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
        private readonly ITaskService _taskService;

        public CoursesListController(ICourseService courseService, IMapper mapper, ILanguageService languageService, UserManager<User> userManager, ITaskService taskService)
        {
            _courseService = courseService;
            _mapper = mapper;
            _languageService = languageService;
            _userManager = userManager;
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

        [HttpPost]
        public async Task<IActionResult> AddCourse(string name, string description, int language)
        {
            var curUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var course = new CourseDTO() { Name = name, Description = description, LanguageId = language, CreateUserId = curUser.Id };

            await _courseService.CreateCourse(course);

            return RedirectToAction("MyCourses", "CoursesList");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int courseId)
        {
            var courseDTO = await _courseService.GetById(courseId);
            var courseVM = _mapper.Map<CourseViewModel>(courseDTO);

            var languages = new List<LanguageViewModel>();
            var languagesDTO = _languageService.GetAll();

            var tasks = new List<TaskViewModel>();
            var tasksDTO = await _taskService.GetAllByCourseId(courseId);

            foreach (var taskDTO in tasksDTO)
            {
                tasks.Add(_mapper.Map<TaskViewModel>(taskDTO));
            }

            foreach (var language in languagesDTO)
            {
                languages.Add(_mapper.Map<LanguageViewModel>(language));
            }

            var result = new EditCourseViewModel(tasks, courseVM) { Languages = languages };

            return View(result);
        }

        public IActionResult AddTask(TaskViewModel task)
        {
            var taskdt = new TaskDTO { Text = task.Text, CourseId = task.CourseId };
            _taskService.Create(taskdt);

            return RedirectToAction("Edit", new { task.CourseId });
        }
    }
}
