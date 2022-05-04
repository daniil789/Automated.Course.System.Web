using System;
using System.Collections.Generic;

#nullable disable

namespace Automated.Course.System.DAL.Entities
{
    public partial class Task
    {
        public Task()
        {
            Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string TaskText { get; set; }
        public int ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
