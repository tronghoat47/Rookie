using App.Domain.Interfaces;
using App.Domain.Models;
using System.Linq.Expressions;

namespace App.Application.Interfaces.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _unitOfWork.EmployeeRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployees(params Expression<Func<Employee, object>>[] includeProperties)
        {
            return await _unitOfWork.EmployeeRepository.GetAllAsync(null, includeProperties);
        }

        public async Task<Employee> GetEmployee(long id)
        {
            return await _unitOfWork.EmployeeRepository.GetAsync(x => x.Id == id);
        }

        public async Task<Employee> GetEmployee(long id, params Expression<Func<Employee, object>>[] includeProperties)
        {
            return await _unitOfWork.EmployeeRepository.GetAsync(x => x.Id == id, includeProperties);
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            if (employee == null)
                return false;
            await _unitOfWork.EmployeeRepository.AddAsync(employee);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            if (employee == null)
                return false;
            var employeeExisted = await _unitOfWork.EmployeeRepository
                .GetAsync(x => x.Id == employee.Id,
                            x => x.Department,
                            x => x.Salary
            );
            if (employeeExisted == null)
                return false;

            employeeExisted.Name = employee.Name;
            employeeExisted.DateOfBirth = employee.DateOfBirth;
            employeeExisted.Email = employee.Email;
            employeeExisted.Phone = employee.Phone;
            employeeExisted.Address = employee.Address;
            employeeExisted.DepartmentId = employee.DepartmentId;
            employeeExisted.JoinDate = employee.JoinDate;
            employeeExisted.Salary.Amount = employee.Salary.Amount;

            _unitOfWork.EmployeeRepository.Update(employeeExisted);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> DeleteEmployee(long id)
        {
            var employee = await _unitOfWork.EmployeeRepository
                .GetAsync(x => x.Id == id);
            if (employee == null)
                return false;
            _unitOfWork.EmployeeRepository.Delete(employee);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<dynamic> GetByQueryAsync(string query)
        {
            return await _unitOfWork.EmployeeRepository.GetByQueryAsync(query);
        }
    }
}