using AutoMapper;
using Automated.Course.System.BLL.DTO;
using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.DAL.Entities;
using Automated.Course.System.MapperExtension;
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
        private readonly IAnswerService _answerService;

        public CoursesListController(ICourseService courseService, IMapper mapper, ILanguageService languageService, UserManager<User> userManager, ITaskService taskService
            , IAnswerService answerService)
        {
            _courseService = courseService;
            _mapper = mapper;
            _languageService = languageService;
            _userManager = userManager;
            _taskService = taskService;
            _answerService = answerService;
        }

        public async Task<IActionResult> Index()
        {
            var result = _mapper.MapList<CourseViewModel>(await _courseService.GetAll());
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> MyCourses()
        {
            var languages = _mapper.MapList<LanguageViewModel>(_languageService.GetAll());

            var curUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var coursesDTO = await _courseService.GetAllByUserId(curUser.Id);
            var coursesListVM = _mapper.MapList<CourseViewModel>(coursesDTO);         
         
            var result = new CoursesListViewModel(coursesListVM, languages);

            return View(result);
        }

        [Authorize(Roles = "teacher")]
        [HttpPost]
        public async Task<IActionResult> AddCourse(string name, string description, int language)
        {
            var curUser = await _userManager.FindByNameAsync(User.Identity.Name);

            var course = new CourseDTO() { Name = name, Description = description, LanguageId = language, CreateUserId = curUser.Id };

            await _courseService.CreateCourse(course);

            return RedirectToAction("MyCourses", "CoursesList");
        }

        [Authorize(Roles = "teacher")]
        [HttpGet]
        public async Task<IActionResult> Edit(int courseId)
        {
            var courseDTO = await _courseService.GetById(courseId);
            var courseVM = _mapper.Map<CourseViewModel>(courseDTO);

            var languages =_mapper.MapList<LanguageViewModel>(_languageService.GetAll());

            var tasks = _mapper.MapList<TaskViewModel>(await _taskService.GetAllByCourseId(courseId));

            foreach (var task in tasks)
            {
                var answers = _mapper.MapList<AnswerViewModel>(await _answerService.GetAllByTaskId(task.Id));

                task.Answers = answers;
            }

            var result = new EditCourseViewModel(tasks, courseVM) { Languages = languages };

            return View(result);
        }

        [Authorize(Roles = "teacher")]
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskViewModel task)
        {
            var taskDTO = new TaskDTO { Text = task.Text, CourseId = task.CourseId };
            var taskId = await _taskService.Create(taskDTO);

            foreach (var answer in task.Answers)
            {
                var answerDTO = new AnswerDTO() { Value = answer.Value, IsRight = answer.IsRight, TaskId = taskId };
                await _answerService.Create(answerDTO);

            }

            return RedirectToAction("Edit", new { task.CourseId });
        }
    }
}
