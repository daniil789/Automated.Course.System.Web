using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.BLL.DTO
{
    class AnswerDTO
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsRight { get; set; }
    }
}
