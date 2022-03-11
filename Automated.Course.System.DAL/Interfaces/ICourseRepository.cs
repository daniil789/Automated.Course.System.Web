using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Entities.Course>> GetAll();
        Task<Entities.Course> GetById(int id);
        Task Create(Entities.Course item);
        Task Update(Entities.Course item);
        Task Delete(int id);
    }
}
