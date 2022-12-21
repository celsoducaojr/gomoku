using Gomoku.Domain.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace Gomoku.Domain.ChainPatterns
{
    public interface IBackwardDiagonalChainPattern : IChainPattern { }

    public class BackwardDiagonalChainPattern : ChainPatternBase, IBackwardDiagonalChainPattern
    {
        IChainPatternRepository _repository;

        public BackwardDiagonalChainPattern(IChainPatternRepository repository)
        {
            _repository = repository;
        }

        public ChainList GetChains()
        {
            return _repository.GetChains();
        }

        public bool ConfirmPlacement(Point point, out Chain chain)
        {
            var chains = _repository.GetChains();

            var c = chains.Where(p => p[0].Difference == point.Difference).FirstOrDefault();

            if (c != null)
            {
                chain = Insert(c, point);
                if (chain != null)
                    return true;
                else
                {
                    chain = null;
                    return false;
                }
            }
            else
            {
                chains.Add(new Chain { point });

                chain = null;
                return false;
            }
        }

        public void Clear()
        {
            _repository.Clear();
        }
    }
}
