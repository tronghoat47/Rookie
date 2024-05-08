namespace API_Assignment_Day1.Models
{
    public class DummyTaskData
    {
        public static List<MyTask> Tasks = new List<MyTask>
        {
            new MyTask { Id = Guid.NewGuid(), Title = "Task 1", IsCompleted = false },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 2", IsCompleted = true },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 3", IsCompleted = false },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 4", IsCompleted = true },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 5", IsCompleted = false },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 6", IsCompleted = true },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 7", IsCompleted = false },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 8", IsCompleted = true },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 9", IsCompleted = false },
            new MyTask { Id = Guid.NewGuid(), Title = "Task 10", IsCompleted = true }
        };
    }
}
