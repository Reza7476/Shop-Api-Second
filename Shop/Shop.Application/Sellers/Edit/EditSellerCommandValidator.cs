using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Sellers.Edit
{
    public class EditSellerCommandValidator : AbstractValidator<EditSellerCommand>
    {

        public EditSellerCommandValidator()
        {
            RuleFor(f => f.ShopName)
                .NotEmpty().WithMessage(ValidationMessages.required("نام فروشگاه"));

            RuleFor(f => f.NationalCode)
                .NotEmpty().WithMessage(ValidationMessages.required(" کد ملی"))
                .ValidNationalId();
        }
    }
}
