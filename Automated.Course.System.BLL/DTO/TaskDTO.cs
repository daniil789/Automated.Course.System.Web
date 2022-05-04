using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string TaskText { get; set; }
        public int ChapterId { get; set; }
    }
}
