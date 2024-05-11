using App.API.ViewModels.ModelRequests;
using App.API.ViewModels.ModelResponses;
using App.Application.Services;
using App.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/project-employees")]
    public class ProjectEmployeeController : Controller
    {
        private readonly IProjectEmployeeService _projectEmployeeService;

        public ProjectEmployeeController(IProjectEmployeeService projectEmployeeService)
        {
            _projectEmployeeService = projectEmployeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjectEmployees()
        {
            var projectEmployees = await _projectEmployeeService.GetProjectEmployees();
            if (!projectEmployees.Any())
                return NotFound("Don't have any project employee");
            return Ok(projectEmployees.ToList().ConvertAll(proEmp => new ProjectEmployeeResponse(proEmp)));
        }

        [HttpGet("{projectId}/{employeeId}")]
        public async Task<IActionResult> GetProjectEmployee(long projectId, long employeeId)
        {
            var projectEmployee = await _projectEmployeeService.GetProjectEmployee(projectId, employeeId);
            if (projectEmployee == null)
                return NotFound("Project employee not found");
            return Ok(new ProjectEmployeeResponse(projectEmployee));
        }

        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetProjectEmployeesByProject(long projectId)
        {
            var projectEmployees = await _projectEmployeeService.GetProjectEmployeesByProject(projectId);
            if (!projectEmployees.Any())
                return NotFound("Don't have any project employee");
            return Ok(projectEmployees.ToList().ConvertAll(proEmp => new ProjectEmployeeResponse(proEmp)));
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetProjectEmployeesByEmployee(long employeeId)
        {
            var projectEmployees = await _projectEmployeeService.GetProjectEmployeesByEmployee(employeeId);
            if (!projectEmployees.Any())
                return NotFound("Don't have any project employee");
            return Ok(projectEmployees.ToList().ConvertAll(proEmp => new ProjectEmployeeResponse(proEmp)));
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectEmployee(ProjectEmployeeCreateRequest projectEmployeeRequest)
        {
            try
            {
                var projectEmployee = new ProjectEmployee
                {
                    ProjectId = projectEmployeeRequest.ProjectId,
                    EmployeeId = projectEmployeeRequest.EmployeeId,
                    IsWorking = true
                };
                var isSuccess = await _projectEmployeeService.CreateProjectEmployee(projectEmployee);
                if (!isSuccess)
                    return BadRequest("Add project employee failed");
                return Ok(new ProjectEmployeeResponse(projectEmployee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{projectId}/{employeeId}")]
        public async Task<IActionResult> UpdateProjectEmployee(long projectId, long employeeId, ProjectEmployeeUpdateRequest projectEmployeeRequest)
        {
            try
            {
                var projectEmployee = await _projectEmployeeService.GetProjectEmployee(projectId, employeeId);
                if (projectEmployee == null)
                    return NotFound("Project employee not found");

                projectEmployee.IsWorking = projectEmployeeRequest.IsWorking;
                var isSuccess = await _projectEmployeeService.UpdateProjectEmployee(projectEmployee);
                if (!isSuccess)
                    return BadRequest("Update project employee failed");
                return Ok(new ProjectEmployeeResponse(projectEmployee));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{projectId}/{employeeId}")]
        public async Task<IActionResult> DeleteProjectEmployee(long projectId, long employeeId)
        {
            try
            {
                var projectEmployee = await _projectEmployeeService.GetProjectEmployee(projectId, employeeId);
                if (projectEmployee == null)
                    return NotFound("Project employee not found");

                var isSuccess = await _projectEmployeeService.DeleteProjectEmployee(projectId, employeeId);
                if (!isSuccess)
                    return BadRequest("Delete project employee failed");
                return Ok("Delete project employee successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}