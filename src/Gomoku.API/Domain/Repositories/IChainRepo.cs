using System.Collections.Generic;

namespace Gomoku.Domain.Repositories
{
    public interface IChainRepo
    {
        public IList<List<Point>> Chains { get; }
    }
}
