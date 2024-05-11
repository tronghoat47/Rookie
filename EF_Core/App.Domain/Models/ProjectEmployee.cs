namespace App.Domain.Models
{
    public class ProjectEmployee
    {
        public long ProjectId { get; set; }
        public long EmployeeId { get; set; }
        public bool IsWorking { get; set; }
        public Project? Project { get; set; }
        public Employee? Employee { get; set; }
    }
}