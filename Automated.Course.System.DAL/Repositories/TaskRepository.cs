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
    public class TaskRepository : ITaskRepository
    {
        AppSettings _settings;

        public TaskRepository(AppSettings settings)
        {
            _settings = settings;
        }

        public async Task Create(Entities.Task item)
        {
            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.InsertTask, item.TaskText, item.ChapterId), conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Entities.Task>> GetAllByChapterId(int chapterId)
        {
            List<Entities.Task> result = new List<Entities.Task>();

            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.GetAllByChapterIdQuery, chapterId), conn))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Entities.Task { Id = reader.GetInt32(0), TaskText = reader.GetString(1), ChapterId = reader.GetInt32(2) });
                }
            }
            await conn.CloseAsync();

            return result;
        }

        public Task<Entities.Task> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public global::System.Threading.Tasks.Task Update(Entities.Task item)
        {
            throw new NotImplementedException();
        }
    }
}
