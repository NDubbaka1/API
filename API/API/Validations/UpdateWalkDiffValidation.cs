using FluentValidation;

namespace API.Validations
{
    public class UpdateWalkDiffValidation : AbstractValidator<Model.DTO.UpdateWalkDiff>
    {
        public UpdateWalkDiffValidation() {
            RuleFor(x => x.Code).NotEmpty();
        }
    }
}
