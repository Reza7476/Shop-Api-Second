using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Create
{
    public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
    {
        public CreateSellerCommandValidator()
        {
            RuleFor(f => f.ShopName)

                .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه "));

            RuleFor(f => f.NatiaonalCode)

                .NotEmpty().WithMessage(ValidationMessages.required("کد ملی  "))
                .ValidNationalId();
        }
    }




}
