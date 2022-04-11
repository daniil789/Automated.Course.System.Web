using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Models
{
    public class AddCourseViewModel
    {
        public AddCourseViewModel()
        {

            Languages = new List<LanguageViewModel>();
        }

        public List<LanguageViewModel> Languages { get; set; }
    }
}
