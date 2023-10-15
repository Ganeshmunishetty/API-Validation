using APIValidation.Model;
using FluentValidation;

namespace APIValidation.Validation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            //RuleFor(u => u.Id).GreaterThanOrEqualTo(1);
            RuleFor(u => u.Name).NotNull().NotEmpty().WithMessage("name cannot be null");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email Required");
            RuleFor(u => u.Age).NotEmpty().NotNull().GreaterThanOrEqualTo(21).LessThanOrEqualTo(99).WithMessage("Invalid age");
            RuleFor(u => u.PhoneNumber).NotNull().NotEmpty().MinimumLength(10).MaximumLength(10).WithMessage("Invalid phone number");
            RuleFor(u => u.address).NotEmpty().MaximumLength(40);
       
        }
    }
}
