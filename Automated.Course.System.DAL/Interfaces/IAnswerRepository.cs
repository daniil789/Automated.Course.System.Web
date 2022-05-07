using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL.Interfaces
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Entities.Answer>> GetAllByTaskId(int taskId);
        Task<Entities.Answer> GetById(int id);
        Task Create(Entities.Answer item);
        Task Update(Entities.Answer item);
        Task Delete(int id);
    }
}
