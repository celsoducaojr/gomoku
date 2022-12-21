using Gomoku.Domain;
using Gomoku.Domain.ChainPatterns;
using Gomoku.Domain.IRepositories;
using Moq;

namespace Gomoku.Test.Infra
{
    public abstract class BaseUnitTest
    {
        #region Build Chains

        public IHorizontalChainPattern GetHorizontalChain()
        {
            var repository = new Mock<IChainPatternRepository>();
            repository.Setup(x => x.GetChains())
                .Returns(new ChainList() {
                    new Chain {
                        new Point(1, 1),
                        new Point(1, 2),
                        new Point(1, 3),
                        new Point(1, 4),
                    }
                });
            return new HorizontalChainPattern(repository.Object);
        }
        public IVerticalChainPattern GetVerticalChain()
        {
            var repository = new Mock<IChainPatternRepository>();
            repository.Setup(x => x.GetChains())
                .Returns(new ChainList() {
                    new Chain {
                        new Point(2, 5),
                        new Point(3, 5),
                        new Point(4, 5),
                        new Point(5, 5),
                    }
                });
            return new VerticalChainPattern(repository.Object);
        }
        public IForwardDiagonalChainPattern GetForwardDiagonalChain()
        {
            var repository = new Mock<IChainPatternRepository>();
            repository.Setup(x => x.GetChains())
                .Returns(new ChainList() {
                    new Chain {
                        new Point(5, 1),
                        new Point(4, 2),
                        new Point(3, 3),
                        new Point(2, 4),
                    }
                });
            return new ForwardDiagonalChainPattern(repository.Object);
        }
        public IBackwardDiagonalChainPattern GetBackwardDiagonalChain()
        {
            var repository = new Mock<IChainPatternRepository>();
            repository.Setup(x => x.GetChains())
                .Returns(new ChainList() {
                    new Chain {
                        new Point(2, 6),
                        new Point(3, 7),
                        new Point(4, 8),
                        new Point(5, 9),
                    }
                });

            return new BackwardDiagonalChainPattern(repository.Object);
        }

        #endregion

    }
}
