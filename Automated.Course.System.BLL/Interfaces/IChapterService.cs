using Automated.Course.System.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Interfaces
{
    public interface IChapterService
    {
        Task<IEnumerable<ChapterDTO>> GetAllByCourseId(int courseId);
        Task<ChapterDTO> GetById(int id);
        Task CreateChapter(ChapterDTO chapter);
        Task DeleteChapter(int id);
    }
}

