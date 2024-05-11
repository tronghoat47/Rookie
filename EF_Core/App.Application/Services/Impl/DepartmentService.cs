using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Application.Services.Impl
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _unitOfWork.DepartmentRepository.GetAllAsync();
        }

        public async Task<Department> GetDepartment(long id)
        {
            return await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == id);
        }

        public async Task<bool> CreateDepartment(Department department)
        {
            if (department == null)
                return false;
            await _unitOfWork.DepartmentRepository.AddAsync(department);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> UpdateDepartment(Department department)
        {
            if (department == null)
                return false;
            var departmentExisted = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == department.Id);
            if (departmentExisted == null)
                return false;

            departmentExisted.Name = department.Name;
            departmentExisted.Location = department.Location;

            _unitOfWork.DepartmentRepository.Update(department);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> DeleteDepartment(long id)
        {
            var department = await _unitOfWork.DepartmentRepository.GetAsync(x => x.Id == id);
            if (department == null)
                return false;
            _unitOfWork.DepartmentRepository.Delete(department);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }
    }
}