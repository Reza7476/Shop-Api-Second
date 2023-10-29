using FluentValidation;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;

namespace Shop.Application.Orders.CheckOut
{
    public class CheckOutOrderCommandValidator : AbstractValidator<CheckOutOrderCommand>
    {
        public CheckOutOrderCommandValidator()
        {
            RuleFor(f => f.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام  "));

            RuleFor(f => f.Family)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام خانوادگی"));

            RuleFor(f => f.Province)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("استان  "));


            RuleFor(f => f.City)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("شهر  "));

            RuleFor(f => f.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage(ValidationMessages.required("نام  "))
                .MinimumLength(11).WithMessage("شماره موبایل نامعتبر است")
                .MaximumLength(11).WithMessage("شماره موبایل نامعتبر است");

            RuleFor(f => f.NationalCode)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("کد ملی  "))
               .MinimumLength(10).WithMessage("کد ملی نامعتبر است")
               .MaximumLength(10).WithMessage("کد ملی نامعتبر است")
               .ValidNationalId();

            RuleFor(f => f.PostalAddress)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("کدپستی  "));

            RuleFor(f => f.PostalCode)
               .NotNull()
               .NotEmpty()
               .WithMessage(ValidationMessages.required("کدپستی  "));

           
        }
    }
}
