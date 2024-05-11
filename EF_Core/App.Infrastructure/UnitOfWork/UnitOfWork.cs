using App.Domain.Interfaces;
using App.Infrastructure.Repositories;

namespace App.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RookieDBContext _context;
        private IEmployeeRepository _employeeRepository;
        private ISalaryRepository _salaryRepository;
        private IDepartmentRepository _departmentRepository;
        private IProjectRepository _projectRepository;
        private IProjectEmployeeRepository _projectEmployeeRepository;

        public UnitOfWork(RookieDBContext context)
        {
            _context = context;
        }

        public IEmployeeRepository EmployeeRepository
            => _employeeRepository ??= new EmployeeRepository(_context);

        public ISalaryRepository SalaryRepository
            => _salaryRepository ??= new SalaryRepository(_context);

        public IDepartmentRepository DepartmentRepository
            => _departmentRepository ??= new DepartmentRepository(_context);

        public IProjectRepository ProjectRepository
            => _projectRepository ??= new ProjectRepository(_context);

        public IProjectEmployeeRepository ProjectEmployeeRepository
            => _projectEmployeeRepository ??= new ProjectEmployeeRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}