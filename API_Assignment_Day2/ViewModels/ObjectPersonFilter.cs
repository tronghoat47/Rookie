using ProjectStructure.Domain.ValidationAttributes;

namespace API_Assignment_Day2.ViewModels
{
    public class ObjectPersonFilter
    {
        public string? Name { get; set; }
        /// <summary>
        /// Accepts value: unknown(0), male(1), female(2), other(3)
        /// </summary>
        [ValidGenderTypeAttribute]
        public string? Gender { get; set; }
        public string? BirthPlace { get; set; }
    }
}
