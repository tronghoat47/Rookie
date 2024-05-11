using App.Domain.Models;

namespace App.API.ViewModels.ModelResponses
{
    public class ProjectResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }

        public ProjectResponse(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            StartDate = project.StartDate.ToString("MM/dd/yyyy");
            EndDate = project.EndDate.ToString("MM/dd/yyyy");
            Status = project.Status;
        }
    }
}