using System;
using System.Collections.Generic;

#nullable disable

namespace Automated.Course.System.DAL.Entities
{
    public partial class Answer
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int? TaskId { get; set; }
        public bool IsRight { get; set; }

        public virtual Task Task { get; set; }
    }
}
