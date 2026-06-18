using FluentValidation;

namespace ParcleManagement.WebApps.Validator
{
    public class LoginModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool RememberMe { get; set; } = false;
    }

    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                    .WithMessage("Email address is required.")
                .EmailAddress()
                    .WithMessage("Please enter a valid email address (e.g. you@company.com).");

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage("Password is required.")
                .MinimumLength(8)
                    .WithMessage("Password must be at least 8 characters long.");
        }
    }
}