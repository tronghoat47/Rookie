using App.API.ViewModels.ModelRequests;
using App.API.ViewModels.ModelResponses;
using App.Application.Interfaces;
using App.Domain.Models;
using App.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static App.API.ViewModels.ModelResponses.EmployeeProjectResponse;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly RookieDBContext _context;

        public EmployeeController(IEmployeeService employeeService, RookieDBContext context)
        {
            _employeeService = employeeService;
            _context = context;
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

        [HttpGet("employees-department")]
        public async Task<IActionResult> GetEmployeesDepartment()
        {
            var emps = _context.Database
                .SqlQueryRaw<EmployeeDepartmentResponse>
                (@"SELECT e.*, d.Name AS DepartmentName
                    FROM Employees e
                    JOIN Departments d ON e.DepartmentId = d.Id");
            return Ok(emps);
        }

        [HttpGet("employees-projects")]
        public async Task<IActionResult> GetEmployeesProjects()
        {
            var emps = _context.Database
                .SqlQueryRaw<EmployeeProjectResponseQuery>
                (@"SELECT
                    e.Id AS EmployeeId,
                    e.Name AS EmployeeName,
                    e.DateOfBirth AS EmployeeDateOfBirth,
                    e.Address AS EmployeeAddress,
                    e.Email AS EmployeeEmail,
                    e.Phone AS EmployeePhone,
                    e.JoinDate AS EmployeeJoinDate,
                    e.DepartmentId,
                    JSON_QUERY(
                        (SELECT
                            p.Id AS ProjectId,
                            p.Name AS ProjectName,
                            p.StartDate AS ProjectStartDate,
                            p.EndDate AS ProjectEndDate,
                            p.Status AS ProjectStatus,
                            p.Description AS ProjectDescription
                        FROM
                            Projects p
                        JOIN
                            ProjectEmployees pe ON p.Id = pe.ProjectId
                        WHERE
                            pe.EmployeeId = e.Id
                        FOR JSON PATH)
                    ) AS Projects
                FROM
                    Employees e");

            var employeeProjects = emps.Select(e => new EmployeeProjectResponse
            {
                EmployeeId = e.EmployeeId,
                EmployeeName = e.EmployeeName,
                EmployeeDateOfBirth = e.EmployeeDateOfBirth,
                EmployeeAddress = e.EmployeeAddress,
                EmployeeEmail = e.EmployeeEmail,
                EmployeePhone = e.EmployeePhone,
                EmployeeJoinDate = e.EmployeeJoinDate,
                DepartmentId = e.DepartmentId,
                Projects = e.Projects != null
        ? JsonConvert.DeserializeObject<List<ProjectCustom>>(e.Projects)
        : null
            });
            return Ok(employeeProjects);
        }

        [HttpGet("filter/{salary}/{joinDate}")]
        public async Task<IActionResult> GetEmployeesSalary(decimal salary, DateTime joinDate)
        {
            var emps = _context.Database
                .SqlQueryRaw<EmployeeSalaryResponse>
                (@"select e.*, d.Name as DepartmentName, s.Amount as Salary
                    from Employees e
                    join Salaries s on e.Id = s.EmployeeId
                    join Departments d on e.DepartmentId = d.Id
                    where s.Amount > {0} and e.JoinDate >= {1}", salary, joinDate);
            return Ok(emps);
        }
    }
}