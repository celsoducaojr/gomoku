using Gomoku.Domain.Enums;
using System.Collections.Generic;

namespace Gomoku.Domain.PlacementResults
{
    public class WinPlacementResult : PlacementResult
    {
        public bool HasWinner { get; } = true;

        public IList<List<Point>> Chains { get; }

        public WinPlacementResult(Player player, IList<List<Point>> chains) 
            : base(true, $"Congratulation! Player {(int)player} was victorious!")
        {
            Chains = chains;
        }
    }
}
