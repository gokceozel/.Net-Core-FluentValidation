using Data.Entities;
using FluentValidation;

namespace SampleAPI.Validations
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş geçilemez";

        public AddressValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Province).NotEmpty().WithMessage(NotEmptyMessage);
        }
    }
}
