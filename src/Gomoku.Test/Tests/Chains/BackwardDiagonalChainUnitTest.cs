using Gomoku.Domain;
using Gomoku.Test.Infra;
using System.Linq;
using Xunit;

namespace Gomoku.Test.Tests.Chains
{
    public class BackwardDiagonalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void DefaultChain_IsValid()
        {
            var chain = GetBackwardDiagonalChain();
            var expectedChain = new Chain {
                new Point(1, 5),
                new Point(2, 6),
                new Point(3, 7),
                new Point(4, 8),
                new Point(5, 9)};

            var result = chain.ConfirmPlacement(new Point(1, 5), out Chain actualChain);

            Assert.True(result);
            Assert.True(Enumerable.SequenceEqual(expectedChain, actualChain));
        }
    }
}
