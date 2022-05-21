using RockStars.Api.Controllers.v1.Songs.Requests;
using FluentValidation;

namespace RockStars.Api.Controllers.v1.Songs.Validators
{
    public class AddSongRequestValidator : AbstractValidator<AddSongRequest>
    {
        public AddSongRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is not valid");

        }
    }
}
