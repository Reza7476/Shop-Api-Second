using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {

        public EditUserCommandValidator()
        {
            RuleFor(f => f.PhoneNumber)
                .ValidPhoneNumber();

            RuleFor(f => f.Email)
              .EmailAddress().WithMessage("ایمیل نا معتبر است");

            RuleFor(f => f.Password)
              .MinimumLength(4).WithMessage("کلمه عبور باید بیشتر از 4 کاراکتر باشد");


            RuleFor(f => f.Avatar)
                .JustImageFile();
        }
    }
}
