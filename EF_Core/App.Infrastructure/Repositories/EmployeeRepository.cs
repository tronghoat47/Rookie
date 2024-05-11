using App.Domain.Interfaces;
using App.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RookieDBContext context) : base(context)
        {
        }

        public async Task<dynamic> GetByQueryAsync(string query)
        {
            return await _context.Employees.FromSqlRaw(query).ToListAsync();
        }
    }
}