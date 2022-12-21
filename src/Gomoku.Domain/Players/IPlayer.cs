using Gomoku.Domain.ChainPatterns;
using System.Collections.Generic;

namespace Gomoku.Domain.Players
{
    public interface IPlayer
    {
        IList<IChainPattern> Placements { get; }
        void Clear();
    }
}
