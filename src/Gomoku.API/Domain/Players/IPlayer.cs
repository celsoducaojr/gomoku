using Gomoku.Domain.Chains;
using System.Collections.Generic;

namespace Gomoku.Domain.Players
{
    public interface IPlayer
    {
        IList<IChain> Placements { get; }
        void Clear();
    }
}
