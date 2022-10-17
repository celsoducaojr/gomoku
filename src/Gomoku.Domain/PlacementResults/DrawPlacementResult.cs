using Gomoku.Domain.Enums;
using System.Collections.Generic;

namespace Gomoku.Domain.PlacementResults
{
    public class DrawPlacementResult : PlacementResult
    {
        public bool HasWinner { get; } = false;

        public DrawPlacementResult() : base(true, "It's a draw!") { }

    }
}
