using API_Assignment_Day1.Models;
using API_Assignment_Day1.Repositories;

namespace API_Assignment_Day1.Services
{
    public class MyTaskService : IMyTaskService
    {
        private readonly IMyTaskRepository _taskRepository;
        public MyTaskService(IMyTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public MyTask CreateTask(MyTask task)
        {
            MyTask existedTask = _taskRepository.GetTaskById(task.Id);
            if (existedTask != null)
            {
                return null;
            }
            return _taskRepository.CreateTask(task);
        }
        public MyTask UpdateTask(MyTask task)
        {
            MyTask existedTask = _taskRepository.GetTaskById(task.Id);
            if (existedTask == null)
            {
                return null;
            }
            return _taskRepository.UpdateTask(task);
        }
        public List<MyTask> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }
        public MyTask GetTaskById(Guid id)
        {
            return _taskRepository.GetTaskById(id);
        }
        public MyTask DeleteTask(Guid id)
        {
            var taskExisted = _taskRepository.GetTaskById(id);
            if (taskExisted != null)
            {
                return _taskRepository.DeleteTask(id);
            }
            return null;
        }

        public List<MyTask> CreateBulkTasks(List<MyTask> tasks)
        {
            List<MyTask> createdTasks = new List<MyTask>();
            foreach (var task in tasks)
            {
                MyTask createdTask = CreateTask(task);
                if (createdTask != null)
                {
                    createdTasks.Add(createdTask);
                }
            }
            return createdTasks;
        }
    }
}
