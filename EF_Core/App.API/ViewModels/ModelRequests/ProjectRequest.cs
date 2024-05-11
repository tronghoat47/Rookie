using System.ComponentModel.DataAnnotations;

namespace App.API.ViewModels.ModelRequests
{
    public class ProjectRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        [RegularExpression("New|In Progress|Completed")]
        public string Status { get; set; }
    }
}