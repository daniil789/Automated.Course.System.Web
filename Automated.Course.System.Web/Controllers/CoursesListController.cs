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

        public CoursesListController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
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

        public async Task<IActionResult> AddCourse()
        {
            return Content("Ещё не сделано(");

        }


    }
}
