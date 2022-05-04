using Automated.Course.System.BLL.Interfaces;
using Automated.Course.System.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult AddTask(int chapterId)
        {
            var taskVM = new TaskViewModel() { ChapterId = 19, TaskText = "Тестовое задание" };

            return View(taskVM);
        }

        
    }
}
