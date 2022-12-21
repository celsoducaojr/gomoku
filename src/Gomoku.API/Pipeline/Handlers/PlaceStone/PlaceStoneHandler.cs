using Gomoku.Domain;
using Gomoku.Domain.PlacementResults;
using Gomoku.Pipeline.Handlers.Create;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Gomoku.Pipeline.Handlers.PlaceStone
{
    public class PlaceStoneHandler : IRequestHandler<PlaceStoneRequest, PlaceStoneResponse>
    {
       IBoard _board;

        public PlaceStoneHandler(IBoard board)
        {
            _board = board;
        }

        public Task<PlaceStoneResponse> Handle(PlaceStoneRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new PlaceStoneResponse()
            {
                PlacementResult = _board.PlaceStone(request.Point)
            });
        }
    }
}
