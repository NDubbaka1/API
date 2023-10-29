using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Validators;

namespace API.Validations
{
    public class Uservalidation :AbstractValidator<Model.DTO.Login>
    {
        public Uservalidation() {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can't be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty");
        }
    }
}
 