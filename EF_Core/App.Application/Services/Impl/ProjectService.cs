using App.Domain.Interfaces;
using App.Domain.Models;

namespace App.Application.Services.Impl
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Project>> GetProjects()
        {
            return await _unitOfWork.ProjectRepository.GetAllAsync();
        }

        public async Task<Project> GetProject(long id)
        {
            return await _unitOfWork.ProjectRepository.GetAsync(x => x.Id == id);
        }

        public async Task<bool> CreateProject(Project project)
        {
            if (project == null)
                return false;
            await _unitOfWork.ProjectRepository.AddAsync(project);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> UpdateProject(Project project)
        {
            if (project == null)
                return false;
            var projectExisted = await _unitOfWork.ProjectRepository.GetAsync(x => x.Id == project.Id);
            if (projectExisted == null)
                return false;

            projectExisted.Name = project.Name;
            projectExisted.Description = project.Description;
            projectExisted.StartDate = project.StartDate;
            projectExisted.EndDate = project.EndDate;

            _unitOfWork.ProjectRepository.Update(project);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }

        public async Task<bool> DeleteProject(long id)
        {
            var project = await _unitOfWork.ProjectRepository.GetAsync(x => x.Id == id);
            if (project == null)
                return false;
            _unitOfWork.ProjectRepository.Delete(project);
            var isSuccess = _unitOfWork.CommitAsync();
            return isSuccess.Result > 0;
        }
    }
}