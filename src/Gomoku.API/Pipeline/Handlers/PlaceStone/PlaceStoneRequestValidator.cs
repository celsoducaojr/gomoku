using FluentValidation;

namespace Gomoku.Pipeline.Handlers.PlaceStone
{
    public class PlaceStoneRequestValidator : AbstractValidator<PlaceStoneRequest>
    {
        public PlaceStoneRequestValidator()
        {
            RuleFor(request => request.Point.X)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(13);

            RuleFor(request => request.Point.Y)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(13);
        }
    }
}
