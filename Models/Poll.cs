using SurveyBasket.Api.Validation_Attribute;

namespace SurveyBasket.Api.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        
        [MaxLenghtSmallerThanNumber(6,ErrorMessage ="lenght is more bigger")]
        public int? testNum { get; set;}
    }
}
