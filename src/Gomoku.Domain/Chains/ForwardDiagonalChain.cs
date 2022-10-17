using Gomoku.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Gomoku.Domain.Chains
{
    public interface IForwardDiagonalChain : IChain { }

    public class ForwardDiagonalChain : BaseChain, IForwardDiagonalChain
    {
        public IChainRepo ChainRepo { get; }

        public ForwardDiagonalChain(IChainRepo chainRepo)
        {
            ChainRepo = chainRepo;
        }

        public void Clear()
        {
            ChainRepo.Chains.Clear();
        }

        public bool ConfirmPlacement(Point point, out List<Point> chain)
        {
            var c = ChainRepo.Chains.Where(p => p[0].Sum == point.Sum).FirstOrDefault();

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
