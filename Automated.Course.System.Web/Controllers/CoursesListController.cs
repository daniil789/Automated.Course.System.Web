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

        private EditCourseViewModel editVm { get; set; }

        public CoursesListController(ICourseService courseService, IMapper mapper, ILanguageService languageService, UserManager<User> userManager, IServiceProvider serviceProvider, IChapterService chapterService)
        {
            _courseService = courseService;
            _mapper = mapper;
            _languageService = languageService;
            _userManager = userManager;
            _serviceProvider = serviceProvider;
            _chapterService = chapterService;
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

            var course = new CourseDTO() { Name = name, Discription = description, LanguageId = language, CreateUserId = curUser.Id };

            await _courseService.CreateCourse(course);

            return RedirectToAction("MyCourses", "CoursesList");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int courseId)
        {
            var course = await _courseService.GetById(courseId);

            var languages = new List<LanguageViewModel>();
            var languagesDTO = _languageService.GetAll();

            var chapters = new List<ChapterViewModel>();
            var chatpersDTO = await _chapterService.GetAllByCourseId(courseId);

            foreach (var chatper in chatpersDTO)
            {
                chapters.Add(_mapper.Map<ChapterViewModel>(chatper));
            }

            foreach (var language in languagesDTO)
            {
                languages.Add(_mapper.Map<LanguageViewModel>(language));
            }

            var result = new EditCourseViewModel() { Id = course.Id, Name = course.Name, Discription = course.Discription, Languages = languages, Chapters = chapters };

            ISession session = _serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            session.SetString("CourseId", result.Id.ToString());

            return View(result);
        }

        public async Task<IActionResult> AddChapter(ChapterViewModel chapter)
        {
            var chapterDTO = new ChapterDTO { CourseId = chapter.CourseId, Name = chapter.Name, Discription = chapter.Description };

            await _chapterService.CreateChapter(chapterDTO);

            return RedirectToAction("Edit", new { chapterDTO.CourseId });
        }
    }
}
