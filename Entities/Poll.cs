using SurveyBasket.Api.Validation_Attribute;

namespace SurveyBasket.Api.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Summery { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public DateOnly StartAt { get; set; }
        public DateOnly EndAt { get; set; }
        public DateOnly timetoplaythegame { get; set; }
    }
}
