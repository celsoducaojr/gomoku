using Gomoku.Domain.Repositories;
using System.Collections.Generic;

namespace Gomoku.Domain.Chains
{
    public interface IChain
    {
        IChainRepo ChainRepo { get; }
        bool ConfirmPlacement(Point point, out List<Point> chain);
        void Clear();
    }
}
