using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Infrastructure.Repositories
{
    public class ProjectEmployeeRepository : GenericRepository<ProjectEmployee>, IProjectEmployeeRepository
    {
        public ProjectEmployeeRepository(RookieDBContext context) : base(context)
        {
        }
    }
}