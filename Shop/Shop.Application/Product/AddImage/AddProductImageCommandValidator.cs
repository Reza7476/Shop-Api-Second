using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Product.AddImage
{
    public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommand>
    {
        public AddProductImageCommandValidator()
        {
            RuleFor(f => f.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();


            RuleFor(f => f.Sequence)
                .GreaterThanOrEqualTo(0);
        }
    }

}
