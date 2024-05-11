namespace App.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IProjectEmployeeRepository ProjectEmployeeRepository { get; }
        ISalaryRepository SalaryRepository { get; }

        Task<int> CommitAsync();

        int Commit();
    }
}