using FluentValidation;

namespace API.Validations
{
    public class AddWalkValidation :AbstractValidator<Model.DTO.AddWalk>
    {
        public AddWalkValidation() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x =>x.WalkdiffcultyID).NotEmpty();
            RuleFor(x =>x.RegionID).NotEmpty();
            RuleFor(x =>x.Name).NotEmpty();
            RuleFor(x=>x.lenght).LessThanOrEqualTo(0);
        }
    }
}
