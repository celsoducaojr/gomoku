using Gomoku.Domain;
using Gomoku.Test.Infra;
using System.Linq;
using Xunit;

namespace Gomoku.Test.Tests.Chains
{
    public class ForwardDiagonalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void DefaultChain_IsValid()
        {
            var chain = GetForwardDiagonalChain();
            var expectedChain = new Chain {
                new Point(5, 1),
                new Point(4, 2),
                new Point(3, 3),
                new Point(2, 4),
                new Point(1, 5)};

            var result = chain.ConfirmPlacement(new Point(1, 5), out Chain actualChain);

            Assert.True(result);
            Assert.True(Enumerable.SequenceEqual(expectedChain, actualChain));
        }
    }
}
