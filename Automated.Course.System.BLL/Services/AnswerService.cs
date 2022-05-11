using AutoMapper;
using Automated.Course.System.BLL.DTO;
using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.DAL.Entities;
using Automated.Course.System.DAL.Interfaces;
using Automated.Course.System.Web.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async global::System.Threading.Tasks.Task Create(AnswerDTO answer)
        {
            await _answerRepository.Create(_mapper.Map<Answer>(answer));
        }

        public global::System.Threading.Tasks.Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnswerDTO>> GetAllByTaskId(int taskId)
        {
            return _mapper.MapList<AnswerDTO>(await _answerRepository.GetAllByTaskId(taskId));
        }

        public Task<AnswerDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
