using App.API.ViewModels.ModelRequests;
using App.API.ViewModels.ModelResponses;
using App.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    [ApiController]
    [Route("api/salaries")]
    public class SalaryController : Controller
    {
        private readonly ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalaries()
        {
            var salaries = await _salaryService.GetSalaries();
            if (!salaries.Any())
                return NotFound("Don't have any salary");
            return Ok(salaries.ToList().ConvertAll(sal => new SalaryResponse(sal)));
        }

        [HttpGet("employee/{id}")]
        public async Task<IActionResult> GetSalaryByEmployee(long id)
        {
            var salary = await _salaryService.GetSalary(x => x.EmployeeId == id);
            if (salary == null)
                return NotFound("Salary not found");
            return Ok(new SalaryResponse(salary));
        }

        [HttpPut("employee/{id}")]
        public async Task<IActionResult> UpdateSalaryByEmployee(long id, SalaryRequest salaryRequest)
        {
            try
            {
                var salary = await _salaryService.GetSalary(x => x.EmployeeId == id);
                if (salary == null)
                    return NotFound("Salary not found");

                salary.Amount = salaryRequest.Amount;
                var isSuccess = await _salaryService.UpdateSalary(salary);
                if (!isSuccess)
                    return BadRequest("Update salary failed");
                return Ok(new SalaryResponse(salary));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}