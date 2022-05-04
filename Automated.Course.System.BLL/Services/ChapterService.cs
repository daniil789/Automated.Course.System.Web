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
    public class ChapterService : IChapterService
    {
        private readonly IChapterRepository _chapterRepository;
        private readonly IMapper _mapper;

        public ChapterService(IChapterRepository chapterRepository, IMapper mapper)
        {
            _chapterRepository = chapterRepository;
            _mapper = mapper;
        }

        public async Task CreateChapter(ChapterDTO chapter)
        {
            await _chapterRepository.Create(_mapper.Map<DAL.Entities.Chapter>(chapter));
        }

        public Task DeleteChapter(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ChapterDTO>> GetAllByCourseId(int courseId)
        {
            var result = new List<ChapterDTO>();
            var chapters = await _chapterRepository.GetAllByCourseId(courseId);

            foreach (var chapter in chapters)
            {
                result.Add(_mapper.Map<ChapterDTO>(chapter));
            }

            return result;
        }

        public Task<ChapterDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
