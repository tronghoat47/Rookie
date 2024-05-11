using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Infrastructure.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(RookieDBContext context) : base(context)
        {
        }
    }
}