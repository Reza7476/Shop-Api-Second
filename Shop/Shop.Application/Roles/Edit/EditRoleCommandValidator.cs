using FluentValidation;

namespace Shop.Application.Roles.Edit
{
    public class EditRoleCommandValidator:AbstractValidator<EditRoleCommand>    
    {
        public EditRoleCommandValidator()
        {
            RuleFor(f=>f.Title)
                .NotEmpty().WithMessage("عنوان");
        }
    }
}
