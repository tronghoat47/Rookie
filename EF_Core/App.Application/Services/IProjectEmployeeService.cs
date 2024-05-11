using App.Domain.Models;

namespace App.Application.Services
{
    public interface IProjectEmployeeService
    {
        Task<IEnumerable<ProjectEmployee>> GetProjectEmployees();

        Task<ProjectEmployee> GetProjectEmployee(long employeeId, long projectId);

        Task<IEnumerable<ProjectEmployee>> GetProjectEmployeesByProject(long projectId);

        Task<IEnumerable<ProjectEmployee>> GetProjectEmployeesByEmployee(long employeeId);

        Task<bool> CreateProjectEmployee(ProjectEmployee projectEmployee);

        Task<bool> UpdateProjectEmployee(ProjectEmployee projectEmployee);

        Task<bool> DeleteProjectEmployee(long employeeId, long projectId);
    }
}