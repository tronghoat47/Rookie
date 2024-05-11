using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Application.Services.Impl
{
    public class ProjectEmployeeService : IProjectEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectEmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProjectEmployee>> GetProjectEmployees()
        {
            return await _unitOfWork.ProjectEmployeeRepository.GetAllAsync();
        }

        public async Task<ProjectEmployee> GetProjectEmployee(long employeeId, long projectId)
        {
            return await _unitOfWork.ProjectEmployeeRepository.GetAsync(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
        }

        public async Task<IEnumerable<ProjectEmployee>> GetProjectEmployeesByProject(long projectId)
        {
            return await _unitOfWork.ProjectEmployeeRepository.GetAllAsync(x => x.ProjectId == projectId);
        }

        public async Task<IEnumerable<ProjectEmployee>> GetProjectEmployeesByEmployee(long employeeId)
        {
            return await _unitOfWork.ProjectEmployeeRepository.GetAllAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<bool> CreateProjectEmployee(ProjectEmployee projectEmployee)
        {
            if (projectEmployee == null)
                return false;
            await _unitOfWork.ProjectEmployeeRepository.AddAsync(projectEmployee);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> UpdateProjectEmployee(ProjectEmployee projectEmployee)
        {
            if (projectEmployee == null)
                return false;
            var projectEmployeeExisted = await _unitOfWork.ProjectEmployeeRepository.GetAsync(x => x.EmployeeId == projectEmployee.EmployeeId && x.ProjectId == projectEmployee.ProjectId);
            if (projectEmployeeExisted == null)
                return false;

            projectEmployeeExisted.IsWorking = projectEmployee.IsWorking;

            _unitOfWork.ProjectEmployeeRepository.Update(projectEmployee);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> DeleteProjectEmployee(long employeeId, long projectId)
        {
            var projectEmployee = await _unitOfWork.ProjectEmployeeRepository.GetAsync(x => x.EmployeeId == employeeId && x.ProjectId == projectId);
            if (projectEmployee == null)
                return false;
            _unitOfWork.ProjectEmployeeRepository.Delete(projectEmployee);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }
    }
}