namespace Gomoku.Domain.PlacementResults
{
    public class WinPlacementResult : PlacementResult
    {
        public bool HasWinner { get; } = true;

        public ChainList Chains { get; }

        public WinPlacementResult(Game.PlayerNumber player, ChainList chains) 
            : base(true, $"Congratulation! Player {(int)player} was victorious!")
        {
            Chains = chains;
        }
    }
}
