using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL
{
   public static class Queries
    {
        public static string GetAllCoursesQuerie = "SELECT Id, Name, discription, Language_id FROM Courses";
        public static string GetAllLanguages = "Select Id, language_name from languages";
    }
}
