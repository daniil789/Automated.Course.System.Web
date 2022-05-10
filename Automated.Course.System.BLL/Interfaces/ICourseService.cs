using Automated.Course.System.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDTO>> GetAll();
        Task<IEnumerable<CourseDTO>> GetAllByUserId(string userId);
        Task <CourseDTO> GetById(int id);
        Task CreateCourse(CourseDTO course);
        Task DeleteCourse(int id);
    }
}
