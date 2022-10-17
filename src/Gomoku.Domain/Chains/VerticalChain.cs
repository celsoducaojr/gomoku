using Gomoku.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Gomoku.Domain.Chains
{
    public interface IVerticalChain : IChain { }
    public class VerticalChain : BaseChain, IVerticalChain
    {
        public IChainRepo ChainRepo { get; }

        public VerticalChain(IChainRepo chainRepo)
        {
            ChainRepo = chainRepo;
        }

        public void Clear()
        {
            ChainRepo.Chains.Clear();
        }

        public bool ConfirmPlacement(Point point, out List<Point> chain)
        {
            var c = ChainRepo.Chains.Where(p => p[0].Y == point.Y).FirstOrDefault();

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

        protected override List<Point> Insert(List<Point> chain, Point point)
        {
            var chained = new List<Point>();
            var inserted = false;

            for (int x = 0; x < chain.Count; x++)
            {
                if (!inserted)
                {
                    if (x == chain.Count - 1)
                    {
                        if (chain[x].X < point.X)
                            chain.Add(point);
                        else
                            chain.Insert(x, point);

                        inserted = true;
                    }
                    else if (chain[x].X > point.X)
                    {
                        chain.Insert(x, point);
                        inserted = true;
                    }
                    else if (chain[x].X == point.X - 1)
                    {
                        chain.Insert(x + 1, point);
                        inserted = true;
                    }
                }

                if (chain.Count >= 4 && x != chain.Count - 1)
                {
                    if (chain[x].X + 1 == chain[x + 1].X || chain[x].X + 1 == point.X)
                    {
                        chained.Add(chain[x]);
                        if (chained.Count == 4)
                        {
                            chained.Add(chain[x + 1]);
                            return chained;
                        }
                    }
                    else
                        chained.Clear();
                }
            }

            return null;
        }
    }
}
