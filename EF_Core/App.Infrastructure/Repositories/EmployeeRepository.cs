using App.Domain.Interfaces;
using App.Domain.Models;
using App.Infrastructure.AccessData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RookieDBContext context)
        {
        }
    }
}
