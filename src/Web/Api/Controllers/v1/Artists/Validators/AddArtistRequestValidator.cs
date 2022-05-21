using RockStars.Api.Controllers.v1.Artists.Requests;
using FluentValidation;

namespace RockStars.Api.Controllers.v1.Artists.Validators
{
    public class AddArtistRequestValidator : AbstractValidator<AddArtistRequest>
    {
        public AddArtistRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is not valid");
        }
    }
}
