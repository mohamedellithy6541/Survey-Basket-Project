namespace SurveyBasket.Api.Models
{
    public class Poll
    {
        public int id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
