using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICourseService _courseService;

        public CatalogController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            var result = new List<CourseViewModel>();
            var coursesDTO = await _courseService.GetAll();

            foreach (var course in coursesDTO)
                result.Add(new CourseViewModel { Id = course.Id, CreateUserId = course.CreateUserId, Description = course.Description, LanguageId = course.LanguageId, Name = course.Name });

            return View(result);
        }
    }
}
