using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Users.AddAddress
{
    public class AddUserAddressCommandValidator:AbstractValidator<AddUserAddressCommand>
    {
        public AddUserAddressCommandValidator()
        {
            RuleFor(f => f.Province)
                .NotEmpty().WithMessage(ValidationMessages.required("استان"));

            RuleFor(f => f.City)
               .NotEmpty().WithMessage(ValidationMessages.required("شهر"));

            RuleFor(f => f.PostalCode)
               .NotEmpty().WithMessage(ValidationMessages.required("کد پستی"));

            RuleFor(f => f.PostalAddress)
               .NotEmpty().WithMessage(ValidationMessages.required("ادرس پستی"));

            RuleFor(f => f.PhoneNumber)
               .NotEmpty().WithMessage(ValidationMessages.required("شماره تلفن"));

            RuleFor(f => f.Name)
               .NotEmpty().WithMessage(ValidationMessages.required("نام"));

            RuleFor(f => f.Family)
               .NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(f => f.NationalCode)
              .NotEmpty().WithMessage(ValidationMessages.required("کد ملی "));
        }

    }
}