using Gomoku.Domain;
using MediatR;


namespace Gomoku.Pipeline.Handlers.PlaceStone
{
    public class PlaceStoneRequest : IRequest<PlaceStoneResponse>
    {
        public Point Point { get; set; }
    }
}
