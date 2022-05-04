using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Models
{
    public class TaskViewModel
    {
        public TaskViewModel()
        {
            Answers = new List<AnswerViewModel>();
        }

        public int Id { get; set; }
        public string TaskText { get; set; }
        public int ChapterId { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
