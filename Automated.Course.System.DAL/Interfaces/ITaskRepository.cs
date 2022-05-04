using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAllByChapterId(int chapterId);
        Task<Entities.Task> GetById(int id);
        Task Create(Entities.Task item);
        Task Update(Entities.Task item);
        Task Delete(int id);
    }
}
