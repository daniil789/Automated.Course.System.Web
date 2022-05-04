using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string TaskText { get; set; }
        public int ChapterId { get; set; }
    }
}
