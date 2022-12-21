using Gomoku.Domain.ChainPatterns;
using System.Collections.Generic;

namespace Gomoku.Domain.Players
{
    public interface IPlayer1 : IPlayer { }

    public class Player1 : IPlayer1
    {
        public IList<IChainPattern> Placements { get; }

        public Player1(IHorizontalChainPattern horizontal, 
            IVerticalChainPattern vertical, 
            IForwardDiagonalChainPattern forwardDiagonal, 
            IBackwardDiagonalChainPattern backwardDiagonal)
        {
            Placements = new List<IChainPattern>
            {
                horizontal,
                vertical,
                forwardDiagonal,
                backwardDiagonal
            };
        }

        public void Clear()
        {
            foreach (var chain in Placements) chain.Clear();
        }
    }
}
