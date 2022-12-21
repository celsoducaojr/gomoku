namespace Gomoku.Domain.PlacementResults
{
    public class DrawPlacementResult : PlacementResult
    {
        public bool HasWinner { get; } = false;

        public DrawPlacementResult() : base(true, "It's a draw!") { }

    }
}
