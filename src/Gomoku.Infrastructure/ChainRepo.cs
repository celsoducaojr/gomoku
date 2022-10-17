using Gomoku.Domain;
using Gomoku.Domain.Repositories;
using System.Collections.Generic;

namespace Gomoku.Infrastructure
{
    public class ChainRepo : IChainRepo
    {
        public IList<List<Point>> Chains { get; set; }

        public ChainRepo()
        {
            Chains = new List<List<Point>>();
        }

       
    }
}
