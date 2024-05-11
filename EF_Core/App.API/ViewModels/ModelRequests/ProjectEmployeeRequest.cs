namespace App.API.ViewModels.ModelRequests
{
    public class ProjectEmployeeCreateRequest
    {
        public long ProjectId { get; set; }
        public long EmployeeId { get; set; }
    }

    public class ProjectEmployeeUpdateRequest
    {
        public bool IsWorking { get; set; }
    }
}