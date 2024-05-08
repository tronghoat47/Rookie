using API_Assignment_Day1.Models;

namespace API_Assignment_Day1.Repositories
{
    public interface IMyTaskRepository
    {
        MyTask CreateTask(MyTask task);
        MyTask UpdateTask(MyTask task);
        List<MyTask> GetAllTasks();
        MyTask GetTaskById(Guid id);
        MyTask DeleteTask(Guid id);
    }
}
