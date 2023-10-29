using FluentValidation;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace API.Validations
{
    public class AddRegionValidation :AbstractValidator<Model.DTO.AddRegion>
    {
        public AddRegionValidation()
        {
            RuleFor(x => x.Code).NotEmpty().WithMessage("Code can't be empty");
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).LessThanOrEqualTo(0);
            RuleFor(x => x.Pop).LessThan(0);
            RuleFor(x=>x.Lat).LessThanOrEqualTo(0);
            RuleFor(x=>x.Long).LessThanOrEqualTo(0);
        }
    }
}
