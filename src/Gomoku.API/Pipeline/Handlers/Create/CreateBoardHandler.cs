using Gomoku.Domain;
using MediatR;
using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace Gomoku.Pipeline.Handlers.Create
{
    public class CreateBoardHandler : IRequestHandler<CreateBoardRequest, Unit>
    {
        IBoard _board;

        public CreateBoardHandler(IBoard board)
        {
            _board = board;
        }

        public Task<Unit> Handle(CreateBoardRequest request, CancellationToken cancellationToken)
        {
            _board.Clear();

            return Unit.Task;
        }
    }
}
