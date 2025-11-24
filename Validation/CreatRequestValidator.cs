using FluentValidation;

namespace SurveyBasket.Api.Validation
{
    public class CreatRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().
                MaximumLength(20);

            RuleFor(x => x.Description)
                .MaximumLength(20)
                .NotEmpty()
                .WithMessage($" desc must be not null :( ");
        }
    }
}
