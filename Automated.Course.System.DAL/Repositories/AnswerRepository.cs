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
    public class AnswerRepository : IAnswerRepository
    {
        AppSettings _settings;

        public AnswerRepository(AppSettings settings)
        {
            _settings = settings;
        }

        public async global::System.Threading.Tasks.Task Create(Answer item)
        {
            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.InsertAnswer, item.Value, item.TaskId, item.IsRight), conn))
            {
                await cmd.ExecuteNonQueryAsync();
            }

            await conn.CloseAsync();
        }


        public global::System.Threading.Tasks.Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Answer>> GetAllByTaskId(int taskId)
        {
            List<Answer> result = new List<Answer>();

            var conn = new NpgsqlConnection(_settings.ConnectionString);
            await conn.OpenAsync();

            using (var cmd = new NpgsqlCommand(string.Format(Queries.GetAllByTaskIdQuery, taskId), conn))
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new Answer { Id = reader.GetInt32(0), Value = reader.GetString(1), TaskId = reader.GetInt32(2), IsRight = reader.GetBoolean(3) });
                }
            }
            await conn.CloseAsync();

            return result;
        }


        public Task<Answer> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public global::System.Threading.Tasks.Task Update(Answer item)
        {
            throw new NotImplementedException();
        }
    }
}
