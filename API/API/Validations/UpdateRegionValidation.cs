using FluentValidation;

namespace API.Validations
{
    public class UpdateRegionValidation :AbstractValidator<Model.DTO.UpdateRegion>
    {
        public UpdateRegionValidation() {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Area).LessThanOrEqualTo(0);
            RuleFor(x => x.Pop).LessThan(0);
            RuleFor(x => x.Lat).LessThanOrEqualTo(0);
            RuleFor(x => x.Long).LessThanOrEqualTo(0);
        }
    }
}
