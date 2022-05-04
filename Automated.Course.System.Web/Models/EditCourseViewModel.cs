using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Models
{
    public class EditCourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public List<LanguageViewModel> Languages { get; set; }
        public List<ChapterViewModel> Chapters { get; set; }

        public EditCourseViewModel()
        {
            Chapters = new List<ChapterViewModel>();
            Languages = new List<LanguageViewModel>();
        }
    }
}
