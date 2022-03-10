using System;
using System.Collections.Generic;

#nullable disable

namespace Automated.Course.System.DAL.Entities
{
    public partial class Language
    {
        public Language()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string LanguageName { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
