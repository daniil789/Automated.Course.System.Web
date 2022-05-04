﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Models
{
    public class EditCourseViewModel
    {
        public CourseViewModel Course { get; set; }
        public List<LanguageViewModel> Languages { get; set; }

    }
}
