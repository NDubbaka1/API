using FluentValidation;

namespace API.Validations
{
    public class AddWalkDiffValidation :AbstractValidator<Model.DTO.AddWalkDiffculty>
    {
        public AddWalkDiffValidation()
        {
            RuleFor(x => x.Code).NotEmpty();
           
        }
    }
}
