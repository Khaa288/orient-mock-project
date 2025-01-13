using FluentValidation;

namespace MockProject.Application.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator() {
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@#$!%*?&]{8,}$")
                .WithMessage("Password must be at least 8 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character.");

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username is required.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Username is required.")
                .EmailAddress()
                .WithMessage("Not a valid email address");
        } 
    }
}
