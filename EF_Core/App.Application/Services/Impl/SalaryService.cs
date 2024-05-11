using App.Domain.Interfaces;
using App.Domain.Models;
using System.Linq.Expressions;

namespace App.Application.Services.Impl
{
    public class SalaryService : ISalaryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SalaryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Salary>> GetSalaries()
        {
            return await _unitOfWork.SalaryRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Salary>> GetSalaries(params Expression<Func<Salary, object>>[] includeProperties)
        {
            return await _unitOfWork.SalaryRepository.GetAllAsync(null, includeProperties);
        }

        public async Task<Salary> GetSalary(long id)
        {
            return await _unitOfWork.SalaryRepository.GetAsync(x => x.Id == id);
        }

        public async Task<Salary> GetSalary(long id, params Expression<Func<Salary, object>>[] includeProperties)
        {
            return await _unitOfWork.SalaryRepository.GetAsync(x => x.Id == id, includeProperties);
        }

        public async Task<Salary> GetSalary(Func<Salary, bool> expression, params Expression<Func<Salary, object>>[] includeProperties)
        {
            return await _unitOfWork.SalaryRepository.GetAsync(expression, includeProperties);
        }

        public async Task<bool> CreateSalary(Salary salary)
        {
            if (salary == null)
                return false;
            await _unitOfWork.SalaryRepository.AddAsync(salary);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> UpdateSalary(Salary salary)
        {
            if (salary == null)
                return false;
            var salaryExisted = await _unitOfWork.SalaryRepository.GetAsync(x => x.Id == salary.Id);
            if (salaryExisted == null)
                return false;

            salaryExisted.Amount = salary.Amount;

            _unitOfWork.SalaryRepository.Update(salary);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> DeleteSalary(long id)
        {
            var salary = await _unitOfWork.SalaryRepository.GetAsync(x => x.Id == id);
            if (salary == null)
                return false;
            _unitOfWork.SalaryRepository.Delete(salary);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }
    }
}