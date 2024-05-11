using App.Domain.Models;

namespace App.API.ViewModels.ModelResponses
{
    public class DepartmentResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public DepartmentResponse(Department department)
        {
            Id = department.Id;
            Name = department.Name;
            Location = department.Location;
        }
    }
}