using FluentValidation;

namespace API.Validations
{
    public class UpdateWalkValidation :AbstractValidator<Model.DTO.UpdateWalk>
    {
        public UpdateWalkValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.WalkdiffcultyID).NotEmpty();
            RuleFor(x => x.RegionID).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.lenght).LessThanOrEqualTo(0);
        }
    }
}
