using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL
{
    public static class Queries
    {
        public static string GetAllCoursesQuery = "SELECT Id, Name, discription, Language_id, Create_User_Id FROM Courses";
        public static string InsertCourse = "Insert into courses(name, discription, language_id, create_user_id) values ('{0}', '{1}', {2}, '{3}' )";
        public static string DeleteCourseByIdQuery = "Delete from courses where id = {0}";

        public static string GetAllLanguages = "Select Id, language_name from languages";
    }
}
