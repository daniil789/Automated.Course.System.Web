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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(TaskDTO task)
        {
            return await _taskRepository.Create(_mapper.Map<DAL.Entities.Task>(task));
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskDTO>> GetAllByCourseId(int courseId)
        {
            return _mapper.MapList<TaskDTO>(await _taskRepository.GetAllByCourseId(courseId));
        }

        public Task<TaskDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
