using System.ComponentModel.DataAnnotations;

namespace App.API.ViewModels.ModelRequests
{
    public class DepartmentRequest
    {
        public string Name { get; set; }

        [RegularExpression("Hanoi|HCM|Danang")]
        public string Location { get; set; }
    }
}