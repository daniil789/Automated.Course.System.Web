﻿using Automated.Course.System.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automated.Course.System.Settings.Settings;
using Npgsql;

namespace Automated.Course.System.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private AppSettings _settings;

        public CourseRepository(AppSettings settings)
        {
            _settings = settings;
        }

        public Task Create(Entities.Course item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Entities.Course>> GetAll()
        {
            List<Entities.Course> result = new List<Entities.Course>();

            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand("SELECT Id, Name, discription, Language_id FROM Courses", conn))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Entities.Course { Id = reader.GetInt32(0), Name = reader.GetString(1), Discription = reader.GetString(2), LanguageId = reader.GetInt32(3) });
                }
            }

            return result;
        }

        public Task<Entities.Course> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Entities.Course item)
        {
            throw new NotImplementedException();
        }
    }
}
