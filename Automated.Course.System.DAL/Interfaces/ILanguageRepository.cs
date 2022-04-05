using Automated.Course.System.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL.Interfaces
{
    public interface ILanguageRepository
    {
        List<Language> GetAll();
        Language GetLanguageById(int id);
    }
}
