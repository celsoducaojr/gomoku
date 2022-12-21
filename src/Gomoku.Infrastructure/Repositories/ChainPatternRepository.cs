using Gomoku.Domain;
using Gomoku.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Infrastructure.Repositories
{
    public class ChainPatternRepository : IChainPatternRepository
    {
        readonly ChainList _chains;

        public ChainPatternRepository(ChainList chains)
        {
            _chains = chains;
        }

        public ChainList GetChains()
        {
            return _chains;
        }

        public void Clear()
        {
            _chains.Clear();
        }

        
    }
}
