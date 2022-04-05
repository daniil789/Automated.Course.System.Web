using Automated.Course.System.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.Interfaces
{
    public interface ILanguageService
    {
        List<LanguageDTO> GetAll();
        LanguageDTO GetLanguageById(int id);
    }
}
