using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDtos;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class AddGuestValidator : AbstractValidator<AddGuestDto>
    {
        public AddGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field can not be null.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname field can not be null.");
            RuleFor(x => x.City).NotEmpty().WithMessage("City field can not be null.");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Name must be atleast 3 character.");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Surname must be atleast 2 character.");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("City must be atleast 3 character.");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Name must not be more than 20 character.");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Surname must not be more than 30 character.");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("City must not be more than 20 character.");

            RuleFor(x => x.Name).Matches("^[^0-9]*$").WithMessage("Name must not contain numbers.");
            RuleFor(x => x.Surname).Matches("^[^0-9]*$").WithMessage("Surname must not contain numbers.");
            RuleFor(x => x.City).Matches("^[^0-9]*$").WithMessage("City must not contain numbers.");
        }
    }
}
