using App.Domain.Models;

namespace App.Application.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();

        Task<Department> GetDepartment(long id);

        Task<bool> CreateDepartment(Department department);

        Task<bool> UpdateDepartment(Department department);

        Task<bool> DeleteDepartment(long id);
    }
}