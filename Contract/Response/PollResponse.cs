namespace SurveyBasket.Api.Contract.Response
{
    public class PollResponse
    {
        public int id { get; set; }
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
