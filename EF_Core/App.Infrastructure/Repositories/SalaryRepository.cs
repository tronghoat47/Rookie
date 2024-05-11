using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Infrastructure.Repositories
{
    public class SalaryRepository : GenericRepository<Salary>, ISalaryRepository
    {
        public SalaryRepository(RookieDBContext context) : base(context)
        {
        }
    }
}