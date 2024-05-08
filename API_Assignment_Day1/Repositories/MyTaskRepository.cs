using API_Assignment_Day1.Models;

namespace API_Assignment_Day1.Repositories
{
    public class MyTaskRepository : IMyTaskRepository
    {
        public MyTask CreateTask(MyTask task)
        {
            DummyTaskData.Tasks.Add(task);
            return task;
        }
        public MyTask UpdateTask(MyTask task)
        {
            var existingTask = DummyTaskData.Tasks.Find(t => t.Id == task.Id);
            existingTask.Title = task.Title;
            existingTask.IsCompleted = task.IsCompleted;
            return existingTask;
        }
        public List<MyTask> GetAllTasks()
        {
            return DummyTaskData.Tasks;
        }
        public MyTask GetTaskById(Guid id)
        {
            return DummyTaskData.Tasks.Find(t => t.Id == id);
        }
        public MyTask DeleteTask(Guid id)
        {
            var task = DummyTaskData.Tasks.Find(t => t.Id == id);
            if (task != null)
            {
                DummyTaskData.Tasks.Remove(task);
                return task;
            }
            return null;
        }
    }
}
