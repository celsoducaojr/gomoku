using Gomoku.Domain.ChainPatterns;
using System.Collections.Generic;

namespace Gomoku.Domain.Players
{
    public interface IPlayer2 : IPlayer { }

    public class Player2 : IPlayer2
    {
        public IList<IChainPattern> Placements { get; }

        public Player2(IHorizontalChainPattern horizontal,
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
