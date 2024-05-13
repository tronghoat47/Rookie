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

    public class EmployeeDepartmentResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class EmployeeProjectResponse
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public DateTime EmployeeJoinDate { get; set; }
        public long DepartmentId { get; set; }
        public List<ProjectCustom>? Projects { get; set; }
    }

    public class EmployeeSalaryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public long DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
    }

    public class EmployeeProjectResponseQuery
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhone { get; set; }
        public DateTime EmployeeJoinDate { get; set; }
        public long DepartmentId { get; set; }
        public string? Projects { get; set; }
    }

    public class ProjectCustom
    {
        public long ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectDescription { get; set; }
    }
}