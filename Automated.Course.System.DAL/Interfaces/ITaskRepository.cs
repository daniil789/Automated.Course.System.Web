﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.DAL.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Entities.Task>> GetAllByCourseId(int courseId);
        Task<Entities.Task> GetById(int id);
        Task<int> Create(Entities.Task item);
        Task Update(Entities.Task item);
        Task Delete(int id);
    }
}
