using System.Collections.Generic;
using System.Linq;

namespace Gomoku.Domain.ChainPatterns
{
    public interface IForwardDiagonalChainPattern : IChainPattern { }

    public class ForwardDiagonalChainPattern : ChainPatternBase, IForwardDiagonalChainPattern
    {
        public ChainList Chains { get; } = new ChainList();

        public void Clear()
        {
            Chains.Clear();
        }

        public bool ConfirmPlacement(Point point, out Chain chain)
        {
            var c = Chains.Where(p => p[0].Sum == point.Sum).FirstOrDefault();

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
    }
}
