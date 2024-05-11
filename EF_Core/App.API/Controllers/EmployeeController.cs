using App.API.ViewModels.ModelRequests;
using App.API.ViewModels.ModelResponses;
using App.Application.Interfaces;
using App.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees(
                e => e.Department,
                e => e.Salary
             );
            if (!employees.Any())
                return NotFound("Don't have any employee");
            return Ok(employees.ToList().ConvertAll(emp => new EmployeeResponse(emp)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(long id)
        {
            var employee = await _employeeService.GetEmployee(id,
                e => e.Department,
                e => e.Salary
            );
            if (employee == null)
                return NotFound("Employee not found");
            return Ok(new EmployeeResponse(employee));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequest employeeRequest)
        {
            try
            {
                var employee = new Employee
                {
                    Name = employeeRequest.Name,
                    DateOfBirth = DateTime.Parse(employeeRequest.DateOfBirth),
                    Address = employeeRequest.Address,
                    Email = employeeRequest.Email,
                    Phone = employeeRequest.Phone,
                    JoinDate = DateTime.Parse(employeeRequest.JoinDate),
                    DepartmentId = employeeRequest.DepartmentId,
                    Salary = new Salary
                    {
                        Amount = employeeRequest.Salary
                    }
                };
                var addedEmployee = await _employeeService.CreateEmployee(employee);
                if (!addedEmployee)
                    return BadRequest("Add employee failed");
                return Ok("Add employee successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(long id, EmployeeRequest employeeRequest)
        {
            try
            {
                var employeeExisted = await _employeeService.GetEmployee(id);
                if (employeeExisted == null)
                    return NotFound("Employee not found");

                var employee = new Employee
                {
                    Id = id,
                    Name = employeeRequest.Name,
                    DateOfBirth = DateTime.Parse(employeeRequest.DateOfBirth),
                    Address = employeeRequest.Address,
                    Email = employeeRequest.Email,
                    Phone = employeeRequest.Phone,
                    JoinDate = DateTime.Parse(employeeRequest.JoinDate),
                    DepartmentId = employeeRequest.DepartmentId,
                    Salary = new Salary
                    {
                        Amount = employeeRequest.Salary
                    }
                };
                var updatedEmployee = await _employeeService.UpdateEmployee(employee);
                if (!updatedEmployee)
                    return BadRequest("Update employee failed");
                return Ok("Update employee successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(long id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);
                if (employee == null)
                    return NotFound("Employee not found");
                var deletedEmployee = await _employeeService.DeleteEmployee(id);
                if (!deletedEmployee)
                    return BadRequest("Delete employee failed");
                return Ok("Delete employee successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("employees-department")]
        //public async Task<IActionResult> GetEmployeesDepartment()
        //{
        //}

        //[HttpGet("employees-projects")]
        //public async Task<IActionResult> GetEmployeesProjects()
        //{
        //}

        //[HttpGet("employees-salary")]
        //public async Task<IActionResult> GetEmployeesSalary()
        //{
        //}
    }
}