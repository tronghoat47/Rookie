using App.Domain.Models;
using System.Linq.Expressions;

namespace App.Application.Services
{
    public interface ISalaryService
    {
        Task<IEnumerable<Salary>> GetSalaries();

        Task<IEnumerable<Salary>> GetSalaries(params Expression<Func<Salary, object>>[] includeProperties);

        Task<Salary> GetSalary(long id);

        Task<Salary> GetSalary(long id, params Expression<Func<Salary, object>>[] includeProperties);

        Task<Salary> GetSalary(Func<Salary, bool> expression, params Expression<Func<Salary, object>>[] includeProperties);

        Task<bool> CreateSalary(Salary salary);

        Task<bool> UpdateSalary(Salary salary);

        Task<bool> DeleteSalary(long id);
    }
}