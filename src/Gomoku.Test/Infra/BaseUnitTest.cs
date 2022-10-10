using Gomoku.Domain;
using Gomoku.Domain.Chains;
using Gomoku.Domain.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Test.Infra
{
    public abstract class BaseUnitTest
    {
        public HorizontalChain GetHorizontalChain()
        {
            var repo = new Mock<IChainRepo>();
            repo.SetupGet(x => x.Chains)
                .Returns(new List<List<Point>>() {
                    new List<Point> {
                        new Point(1, 1),
                        new Point(1, 2),
                        new Point(1, 3),
                        new Point(1, 4),
                    }
                });
            return new HorizontalChain(repo.Object);
        }

        public VerticalChain GetVerticalChain()
        {
            var repo = new Mock<IChainRepo>();
            repo.SetupGet(x => x.Chains)
                .Returns(new List<List<Point>>() {
                    new List<Point> {
                        new Point(2, 5),
                        new Point(3, 5),
                        new Point(4, 5),
                        new Point(5, 5),
                    }
                });
            return new VerticalChain(repo.Object);
        }

        public ForwardDiagonalChain GetForwardDiagonalChain()
        {
            var repo = new Mock<IChainRepo>();
            repo.SetupGet(x => x.Chains)
                .Returns(new List<List<Point>>() {
                    new List<Point> {
                        new Point(5, 1),
                        new Point(4, 2),
                        new Point(3, 3),
                        new Point(2, 4),
                    }
                });
            return new ForwardDiagonalChain(repo.Object);
        }
        public BackwardDiagonalChain GetBackwardDiagonalChain()
        {
            var repo = new Mock<IChainRepo>();
            repo.SetupGet(x => x.Chains)
                .Returns(new List<List<Point>>() {
                    new List<Point> {
                        new Point(2, 6),
                        new Point(3, 7),
                        new Point(4, 8),
                        new Point(5, 9),
                    }
                });
            return new BackwardDiagonalChain(repo.Object);
        }
    }
}
