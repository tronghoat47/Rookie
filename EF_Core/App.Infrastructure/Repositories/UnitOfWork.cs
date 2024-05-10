using App.Domain.Interfaces;
using App.Infrastructure.AccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RookieDBContext _context;
        private IEmployeeRepository _employeeRepository;

        public UnitOfWork(RookieDBContext context)
        {
            _context = context;
        }

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                return _employeeRepository ??= new EmployeeRepository(_context);
            }
        }

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
