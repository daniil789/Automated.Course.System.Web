using Automated.Course.System.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllByCourseId(int courseId);
        Task<TaskDTO> GetById(int id);
        Task Create(TaskDTO task);
        Task Delete(int id);
    }
}
