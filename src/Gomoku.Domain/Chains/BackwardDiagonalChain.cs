using Gomoku.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Gomoku.Domain.Chains
{
    public interface IBackwardDiagonalChain : IChain { }

    public class BackwardDiagonalChain : BaseChain, IBackwardDiagonalChain
    {
        public IChainRepo ChainRepo { get; }

        public BackwardDiagonalChain(IChainRepo chainRepo)
        {
            ChainRepo = chainRepo;
        }

        public void Clear()
        {
            ChainRepo.Chains.Clear();
        }

        public bool ConfirmPlacement(Point point, out List<Point> chain)
        {
            var c = ChainRepo.Chains.Where(p => p[0].Difference == point.Difference).FirstOrDefault();

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
                ChainRepo.Chains.Add(new List<Point> { point });

                chain = null;
                return false;
            }
        }
    }
}
