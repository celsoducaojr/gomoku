using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Domain.IRepositories
{
    public interface IChainPatternRepository : IRepository
    {
        ChainList GetChains();

        // Add SaveChains method here...

        void Clear();
    }
}
