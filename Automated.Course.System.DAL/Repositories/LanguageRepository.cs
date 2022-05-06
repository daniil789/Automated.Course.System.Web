using Automated.Course.System.DAL.Entities;
using Automated.Course.System.DAL.Interfaces;
using Automated.Course.System.Settings.Extensions;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly AppSettings _settings;
        public LanguageRepository(AppSettings settings)
        {
            _settings = settings;
        }

        public Language GetLanguageById(int id)
        {
            throw new NotImplementedException();
        }

        public  List<Language> GetAll()
        {
            var result = new List<Language>();

            var conn = new NpgsqlConnection(_settings.ConnectionString);
            conn.Open();

            using (var cmd = new NpgsqlCommand(Queries.GetAllLanguages, conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    result.Add(new Language { Id = reader.GetInt32(0), Name = reader.GetString(1) });
                }
            }
            conn.Close();

            return result;
        }
    }
}
