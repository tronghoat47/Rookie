using App.API.ViewModels.ModelRequests;
using App.API.ViewModels.ModelResponses;
using App.Application.Services;
using App.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await _projectService.GetProjects();
            if (!projects.Any())
                return NotFound("Don't have any project");
            return Ok(projects.ToList().ConvertAll(pro => new ProjectResponse(pro)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(long id)
        {
            var project = await _projectService.GetProject(id);
            if (project == null)
                return NotFound("Project not found");
            return Ok(new ProjectResponse(project));
        }

        [HttpPost]
        public async Task<IActionResult> AddProject(ProjectRequest projectRequest)
        {
            try
            {
                var project = new Project
                {
                    Name = projectRequest.Name,
                    Description = projectRequest.Description,
                    StartDate = DateTime.Parse(projectRequest.StartDate),
                    EndDate = DateTime.Parse(projectRequest.EndDate),
                    Status = projectRequest.Status
                };
                var isSuccess = await _projectService.CreateProject(project);
                if (!isSuccess)
                    return BadRequest("Add project failed");
                return Ok(new ProjectResponse(project));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(long id, ProjectRequest projectRequest)
        {
            try
            {
                var project = await _projectService.GetProject(id);
                if (project == null)
                    return NotFound("Project not found");
                project.Name = projectRequest.Name;
                project.Description = projectRequest.Description;
                project.StartDate = DateTime.Parse(projectRequest.StartDate);
                project.EndDate = DateTime.Parse(projectRequest.EndDate);
                project.Status = projectRequest.Status;
                var isSuccess = await _projectService.UpdateProject(project);
                if (!isSuccess)
                    return BadRequest("Update project failed");
                return Ok(new ProjectResponse(project));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            try
            {
                var project = await _projectService.GetProject(id);
                if (project == null)
                    return NotFound("Project not found");
                var isSuccess = await _projectService.DeleteProject(id);
                if (!isSuccess)
                    return BadRequest("Delete project failed");
                return Ok("Delete project successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}