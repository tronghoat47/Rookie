using App.Domain.Models;

namespace App.Application.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjects();

        Task<Project> GetProject(long id);

        Task<bool> CreateProject(Project project);

        Task<bool> UpdateProject(Project project);

        Task<bool> DeleteProject(long id);
    }
}