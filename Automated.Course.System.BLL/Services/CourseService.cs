using AutoMapper;
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
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task CreateCourse(CourseDTO course)
        {
            await _courseRepository.Create(_mapper.Map<DAL.Entities.Course>(course));
        }

        public async Task DeleteCourse(int id)
        {
            await _courseRepository.Delete(id);
        }

        public async Task<IEnumerable<CourseDTO>> GetAll()
        {
            var result = new List<CourseDTO>();
            var courses = await _courseRepository.GetAll();

            foreach (var course in courses)
            {
                result.Add(_mapper.Map<CourseDTO>(course));
            }

            return result;
        }

        public async Task<CourseDTO> GetById(int id)
        {
           var course = await _courseRepository.GetById(id);

            return _mapper.Map<CourseDTO>(course);

        }
    }
}
