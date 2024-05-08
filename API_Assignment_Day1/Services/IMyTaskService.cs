using API_Assignment_Day1.Models;

namespace API_Assignment_Day1.Services
{
    public interface IMyTaskService
    {
        MyTask CreateTask(MyTask task);
        MyTask UpdateTask(MyTask task);
        List<MyTask> GetAllTasks();
        MyTask GetTaskById(Guid id);
        MyTask DeleteTask(Guid id);
        List<MyTask> CreateBulkTasks(List<MyTask> tasks);
    }
}
