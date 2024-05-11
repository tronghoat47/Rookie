using App.Domain.Models;

namespace App.API.ViewModels.ModelResponses
{
    public class SalaryResponse
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public long EmployeeId { get; set; }

        public SalaryResponse(Salary salary)
        {
            Id = salary.Id;
            Amount = salary.Amount;
            EmployeeId = salary.EmployeeId;
        }
    }
}