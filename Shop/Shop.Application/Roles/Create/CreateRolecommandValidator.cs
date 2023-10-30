using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create
{
    public class CreateRolecommandValidator:AbstractValidator<CreateRolecommand>
    {
        public CreateRolecommandValidator()
        {
            RuleFor(f => f.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
        }
    }

}
