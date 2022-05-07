using Automated.Course.System.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Interfaces
{
    public interface IAnswerService
    {
        Task<IEnumerable<AnswerDTO>> GetAllByTaskId(int taskId);
        Task<AnswerDTO> GetById(int id);
        Task Create(AnswerDTO answer);
        Task Delete(int id);
    }
}
