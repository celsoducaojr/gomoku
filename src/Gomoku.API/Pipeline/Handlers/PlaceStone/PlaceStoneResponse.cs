using Gomoku.Domain.PlacementResults;
using MediatR;

namespace Gomoku.Pipeline.Handlers.PlaceStone
{
    public class PlaceStoneResponse
    {
        public PlacementResult PlacementResult { get; set; }
    }
}
