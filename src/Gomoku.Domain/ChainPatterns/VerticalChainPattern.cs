using System.Collections.Generic;
using System.Linq;

namespace Gomoku.Domain.ChainPatterns
{
    public interface IVerticalChainPattern : IChainPattern { }
    public class VerticalChainPattern : ChainPatternBase, IVerticalChainPattern
    {
        public ChainList Chains { get; } = new ChainList();

        public void Clear()
        {
            Chains.Clear();
        }

        public bool ConfirmPlacement(Point point, out Chain chain)
        {
            var c = Chains.Where(p => p[0].Y == point.Y).FirstOrDefault();

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
                Chains.Add(new Chain { point });

                chain = null;
                return false;
            }
        }

        protected override Chain Insert(Chain chain, Point point)
        {
            var chained = new Chain();
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
