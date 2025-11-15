namespace SurveyBasket.Api.Contract.Request
{
    public class CreatePollRequest
    {
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
