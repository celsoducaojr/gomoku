using Gomoku.Domain.Repositories;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace Gomoku.Domain.Chains
{
    public interface IHorizontalChain : IChain { }
    public class HorizontalChain : BaseChain, IHorizontalChain
    {
        public IChainRepo ChainRepo { get; }

        public HorizontalChain(IChainRepo chainRepo)
        {
            ChainRepo = chainRepo;
        }

        public void Clear()
        {
            ChainRepo.Chains.Clear();
        }

        public bool ConfirmPlacement(Point point, out List<Point> chain)
        {
            var c = ChainRepo.Chains.Where(p => p[0].X == point.X).FirstOrDefault();

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
