using App.Domain.Models;

namespace App.API.ViewModels.ModelResponses
{
    public class EmployeeResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JoinDate { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }

        public EmployeeResponse(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            DateOfBirth = employee.DateOfBirth.ToString("MM/dd/yyyy");
            Address = employee.Address;
            Email = employee.Email;
            Phone = employee.Phone;
            JoinDate = employee.JoinDate.ToString("MM/dd/yyyy");
            DepartmentId = employee.DepartmentId;
            DepartmentName = employee.Department?.Name ?? "";
            Salary = employee.Salary?.Amount ?? 0;
        }
    }
}