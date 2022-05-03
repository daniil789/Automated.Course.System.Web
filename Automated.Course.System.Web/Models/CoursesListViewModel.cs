using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Models
{
    public class CoursesListViewModel
    {
        public CoursesListViewModel(List<CourseViewModel> courses, List<LanguageViewModel> languages)
        {
            Courses = courses;
            Languages = languages;
        }

        public List<CourseViewModel> Courses { get; set; }
        public List<LanguageViewModel> Languages { get; set; }
    }
}
