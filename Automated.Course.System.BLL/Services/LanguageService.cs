using AutoMapper;
using Automated.Course.System.BLL.DTO;
using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.DAL.Interfaces;
using Automated.Course.System.MapperExtension;
using Automated.Course.System.Settings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageService(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public List<LanguageDTO> GetAll()
        {
            return _mapper.MapList<LanguageDTO>(_languageRepository.GetAll());
        }

        public LanguageDTO GetLanguageById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
