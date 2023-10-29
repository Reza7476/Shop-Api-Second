using FluentValidation;

namespace Shop.Application.Orders.DecreaseItemCount
{
    public class DecreaseItemCountCommandValidator:AbstractValidator<DecreaseItemCountCommand>
    {

        public DecreaseItemCountCommandValidator()
        {
            RuleFor(f => f.Count)
        .GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
        }
    }


}
