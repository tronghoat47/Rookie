using API_Assignment_Day1.DTOs;
using API_Assignment_Day1.Models;
using API_Assignment_Day1.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Assignment_Day1.Controllers
{
    [ApiController]
    [Route("api/my-tasks")]
    public class MyTaskController : Controller
    {
        private readonly IMyTaskService _taskService;
        public MyTaskController(IMyTaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost]
        public IActionResult CreateTask([FromBody] MyTaskDTO taskDTO)
        {
            MyTask myTask = new MyTask
            {
                Id = Guid.NewGuid(),
                Title = taskDTO.Title,
                IsCompleted = taskDTO.IsCompleted
            };
            MyTask createdTask = _taskService.CreateTask(myTask);
            if (createdTask == null)
            {
                return BadRequest("Task already exists");
            }
            return Ok(createdTask);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromBody] MyTaskDTO taskDTO)
        {
            MyTask myTask = new MyTask
            {
                Id = id,
                Title = taskDTO.Title,
                IsCompleted = taskDTO.IsCompleted
            };
            MyTask updatedTask = _taskService.UpdateTask(myTask);
            if (updatedTask == null)
            {
                return NotFound("Task not found");
            }
            return Ok(updatedTask);
        }
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            return Ok(_taskService.GetAllTasks());
        }
        [HttpGet("{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            MyTask task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            return Ok(task);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            MyTask task = _taskService.DeleteTask(id);
            if (task == null)
            {
                return NotFound("Task not found");
            }
            return Ok(task);
        }
        [HttpPost("bulk")]
        public IActionResult CreateBulkTasks([FromBody] List<MyTaskDTO> taskDTOs)
        {
            List<MyTask> tasks = new List<MyTask>();
            foreach (var taskDTO in taskDTOs)
            {
                MyTask task = new MyTask
                {
                    Id = Guid.NewGuid(),
                    Title = taskDTO.Title,
                    IsCompleted = taskDTO.IsCompleted
                };
                tasks.Add(task);
            }
            List<MyTask> createdTasks = _taskService.CreateBulkTasks(tasks);
            return Ok(createdTasks);
        }
        [HttpDelete("bulk")]
        public IActionResult DeleteBulkTasks([FromBody] List<Guid> ids)
        {
            List<MyTask> deletedTasks = new List<MyTask>();
            foreach (var id in ids)
            {
                MyTask task = _taskService.DeleteTask(id);
                if (task != null)
                {
                    deletedTasks.Add(task);
                }
            }
            return Ok(deletedTasks);
        }
    }
}
