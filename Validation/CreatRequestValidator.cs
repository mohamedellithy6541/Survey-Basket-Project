using FluentValidation;

namespace SurveyBasket.Api.Validation
{
    public class CreatRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().
                MaximumLength(20)
                .WithMessage(" {PropertyName} must be max Lenght is {MaxLength}  :( ");
            ;


            RuleFor(x => x.Description)
                .MaximumLength(20)
                .NotEmpty()
                .WithMessage(" {PropertyName} must be not null :( ");
        }
    }
}
