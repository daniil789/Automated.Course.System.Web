using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL.Interfaces
{
    public interface IChapterRepository
    {
        Task<IEnumerable<Entities.Chapter>> GetAllByCourseId(int courseId);
        Task<Entities.Chapter> GetById(int id);
        Task Create(Entities.Chapter item);
        Task Update(Entities.Chapter item);
        Task Delete(int id);
    }
}
