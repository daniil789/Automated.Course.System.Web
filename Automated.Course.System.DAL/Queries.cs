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
        public static string GetCourseById = "SELECT Id, Name, discription, Language_id, Create_User_Id FROM Courses where Id = {0}";
        public static string InsertCourse = "Insert into courses(name, discription, language_id, create_user_id) values ('{0}', '{1}', {2}, '{3}' )";
        public static string DeleteCourseByIdQuery = "Delete from courses where id = {0}";

        public static string GetAllLanguages = "Select Id, language_name from languages";

        public static string GetAllChaptersByCourseIdQuery = "SELECT Id, Name, discription, course_id FROM Chapters WHERE course_id = {0}";
        public static string InsertChapter = "Insert into chapters(name, discription, course_id) values ('{0}', '{1}', {2})";

        public static string GetAllByChapterIdQuery = "SELECT Id, Task_text, Chapter_id FROM Tasks WHERE chapter_id = {0}";
        public static string InsertTask = "Insert into tasks(task_text,chapter_id) values ('{0}',{1})";
    }
}
