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
    public class ChapterRepository : IChapterRepository
    {
        AppSettings _settings;

        public ChapterRepository(AppSettings settings)
        {
            _settings = settings;
        }
        public async global::System.Threading.Tasks.Task Create(Chapter item)
        {
            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.InsertChapter, item.Name, item.Discription, item.CourseId), conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }

        public global::System.Threading.Tasks.Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Chapter>> GetAllByCourseId(int courseId)
        {
            List<Chapter> result = new List<Chapter>();

            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.GetAllChaptersByCourseIdQuery, courseId), conn))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Chapter { Id = reader.GetInt32(0), Name = reader.GetString(1), Discription = reader.GetString(2), CourseId = reader.GetInt32(3) });
                }
            }
            await conn.CloseAsync();

            return result;
        }

        public Task<Chapter> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public global::System.Threading.Tasks.Task Update(Chapter item)
        {
            throw new NotImplementedException();
        }
    }
}
