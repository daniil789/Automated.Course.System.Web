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

        public CoursesListController(ICourseService courseService, IMapper mapper, ILanguageService languageService)
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
                result.Add(_mapper.Map<CourseViewModel>(course));
            }

            return View(result);
        }


        //[HttpGet]
        //public async Task<IActionResult> DeleteCourse(int? id)
        //{
        //    var courseForDelete = await _courseService.GetAll();

        //    var a = courseForDelete.First(x => x.Id == id);

        //    var c = _mapper.Map<CourseViewModel>(a);

        //    return PartialView(c);
        //}

        [HttpGet]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourse(id);

            return RedirectToAction("Index");
        }
    }
}
