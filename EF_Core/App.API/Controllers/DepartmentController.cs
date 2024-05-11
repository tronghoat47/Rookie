using App.API.ViewModels.ModelRequests;
using App.API.ViewModels.ModelResponses;
using App.Application.Services;
using App.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/departments")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departments = await _departmentService.GetDepartments();
            if (!departments.Any())
                return NotFound("Don't have any department");
            return Ok(departments.ToList().ConvertAll(dep => new DepartmentResponse(dep)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartment(long id)
        {
            var department = await _departmentService.GetDepartment(id);
            if (department == null)
                return NotFound("Department not found");
            return Ok(new DepartmentResponse(department));
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentRequest departmentRequest)
        {
            try
            {
                var department = new Department
                {
                    Name = departmentRequest.Name,
                    Location = departmentRequest.Location
                };
                var isSuccess = await _departmentService.CreateDepartment(department);
                if (!isSuccess)
                    return BadRequest("Add department failed");
                return Ok(new DepartmentResponse(department));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(long id, DepartmentRequest departmentRequest)
        {
            try
            {
                var departmentExisted = await _departmentService.GetDepartment(id);
                if (departmentExisted == null)
                    return NotFound("Department not found");

                var department = new Department
                {
                    Id = id,
                    Name = departmentRequest.Name,
                    Location = departmentRequest.Location
                };
                var isSuccess = await _departmentService.UpdateDepartment(department);
                if (!isSuccess)
                    return BadRequest("Update department failed");
                return Ok(new DepartmentResponse(department));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(long id)
        {
            try
            {
                var departmentExisted = await _departmentService.GetDepartment(id);
                if (departmentExisted == null)
                    return NotFound("Department not found");
                var isSuccess = await _departmentService.DeleteDepartment(id);
                if (!isSuccess)
                    return BadRequest("Delete department failed");
                return Ok("Delete department successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}