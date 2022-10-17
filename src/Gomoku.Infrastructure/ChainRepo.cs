using Gomoku.Domain;
using Gomoku.Domain.Repositories;
using System.Collections.Generic;

namespace Gomoku.Infrastructure
{
    public class ChainRepo : IChainRepo
    {
        public IList<List<Point>> Chains { get; } = new List<List<Point>>();
    }
}
