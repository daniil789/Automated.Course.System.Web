﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Automated.Course.System.DAL.Entities
{
    public partial class Course
    {
        public Course()
        {
            Chapters = new HashSet<Chapter>();
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int LanguageId { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
