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
        public string Text { get; set; }
        public int CourseId { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }
}
