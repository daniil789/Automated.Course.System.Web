using AutoMapper;
using Automated.Course.System.BLL.DTO;
using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.DAL.Interfaces;
using Automated.Course.System.Web.Mapper;
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
            return _mapper.MapList<CourseDTO>(await _courseRepository.GetAll());
        }

        public async Task<IEnumerable<CourseDTO>> GetAllByUserId(string userId)
        {
            return _mapper.MapList<CourseDTO>(await _courseRepository.GetAllByUserId(userId));
        }

        public async Task<CourseDTO> GetById(int id)
        {
            var course = await _courseRepository.GetById(id);

            return _mapper.Map<CourseDTO>(course);

        }
    }
}
