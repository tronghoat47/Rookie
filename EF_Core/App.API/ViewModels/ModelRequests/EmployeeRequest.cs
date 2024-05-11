namespace App.API.ViewModels.ModelRequests
{
    public class EmployeeRequest
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string JoinDate { get; set; }
        public long DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}