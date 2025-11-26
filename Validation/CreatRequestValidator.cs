using FluentValidation;

namespace SurveyBasket.Api.Validation
{
    public class CreatRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().
                MinimumLength(5)
                .WithMessage(" {PropertyName} must be Minimum Lenght is {MinLength}  :( ");

            RuleFor(x => x.Notes)
                .MaximumLength(20)
                .WithMessage(" {PropertyName} must be maximum Lenght is {MaxLength} (:")
                .NotEmpty()
                .WithMessage(" {PropertyName} must be not null :( ");
        }
    }
}
