using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Infrastructure.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(RookieDBContext context) : base(context)
        {
        }
    }
}