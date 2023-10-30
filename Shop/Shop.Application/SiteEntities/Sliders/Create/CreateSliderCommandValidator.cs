using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.SiteEntities.Sliders.Create
{
    public class CreateSliderCommandValidator : AbstractValidator<CreateSliderCommand>
    {
        public CreateSliderCommandValidator()
        {
            RuleForEach(f => f.Title)
                .NotNull().WithMessage(ValidationMessages.required("عنوان"));


            RuleForEach(f => f.Link)
                .NotNull().WithMessage(ValidationMessages.required("لینک"));

            RuleFor(f => f.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();
        }
    }
}
