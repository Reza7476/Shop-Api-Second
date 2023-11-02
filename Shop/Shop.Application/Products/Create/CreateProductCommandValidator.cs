using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(f => f.Title)
                .NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

            RuleFor(f => f.Description)
               .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));



            RuleFor(f => f.Slug)
               .NotEmpty().WithMessage(ValidationMessages.required("slug"));


            RuleFor(f => f.ImageFile)
            .JustImageFile();



        }
    }
}
