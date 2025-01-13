using FluentValidation;

namespace MockProject.Application.Commands
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator() {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required");
        }
    }
}
