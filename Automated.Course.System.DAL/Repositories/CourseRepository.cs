using Automated.Course.System.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automated.Course.System.Settings.Extensions;
using Npgsql;

namespace Automated.Course.System.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppSettings _settings;

        public CourseRepository(AppSettings settings)
        {
            _settings = settings;
        }

        public async Task Create(Entities.Course item)
        {
            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.InsertCourse, item.Name, item.Discription, item.LanguageId, item.CreateUserId), conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }

        public async Task Delete(int id)
        {
            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.DeleteCourseByIdQuery, id), conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }

        public async Task<IEnumerable<Entities.Course>> GetAll()
        {
            List<Entities.Course> result = new List<Entities.Course>();

            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(Queries.GetAllCoursesQuery, conn))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Entities.Course { Id = reader.GetInt32(0), Name = reader.GetString(1), Discription = reader.GetString(2), LanguageId = reader.GetInt32(3), CreateUserId = reader.GetString(4) });
                }
            }
            await conn.CloseAsync();

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
