using App.Domain.Models;

namespace App.Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<dynamic> GetByQueryAsync(string query);
    }
}