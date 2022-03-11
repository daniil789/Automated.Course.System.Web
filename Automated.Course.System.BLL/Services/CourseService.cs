using Automated.Course.System.BLL.DTO;
using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Services
{
    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            var result = new List<CourseDTO>();
            var courses = await _courseRepository.GetAll();

            foreach (var course in courses)
            {
                var courseDTO = new CourseDTO() {Id = course.Id, Name = course.Name, Discription = course.Discription };
                result.Add(courseDTO);
            }

            return result;
        }
    }
}
