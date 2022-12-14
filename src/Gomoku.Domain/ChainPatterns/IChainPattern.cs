namespace Gomoku.Domain.ChainPatterns
{
    public interface IChainPattern
    {
        ChainList GetChains();
        bool ConfirmPlacement(Point point, out Chain chain);
        void Clear();
    }

    public abstract class ChainPatternBase
    {
        protected virtual Chain Insert(Chain chain, Point point)
        {
            var chained = new Chain();
            var inserted = false;

            for (int x = 0; x < chain.Count; x++)
            {
                if (!inserted)
                {
                    if (x == chain.Count - 1)
                    {
                        if (chain[x].Y < point.Y)
                            chain.Add(point);
                        else
                            chain.Insert(x, point);

                        inserted = true;
                    }
                    else if (chain[x].Y > point.Y)
                    {
                        chain.Insert(x, point);
                        inserted = true;
                    }
                    else if (chain[x].Y == point.Y - 1)
                    {
                        chain.Insert(x + 1, point);
                        inserted = true;
                    }
                }

                if (chain.Count >= 4 && x != chain.Count - 1)
                {
                    if (chain[x].Y + 1 == chain[x + 1].Y || chain[x].Y + 1 == point.Y)
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
