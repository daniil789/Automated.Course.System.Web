﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.DTO
{
    public class ChapterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int CourseId { get; set; }
    }
}
