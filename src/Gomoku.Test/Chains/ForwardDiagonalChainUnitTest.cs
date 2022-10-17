using Gomoku.Domain;
using Gomoku.Test.Infra;
using System.Collections.Generic;
using Xunit;

namespace Gomoku.Test.Chains
{
    public class ForwardDiagonalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void Case1_IsValid()
        {
            var chain = GetForwardDiagonalChain();

            var result = chain.ConfirmPlacement(new Point(1, 5), out List<Point> actualChain);

            Assert.True(result);
            Assert.True(actualChain[0] == new Point(5, 1));
            Assert.True(actualChain[1] == new Point(4, 2));
            Assert.True(actualChain[2] == new Point(3, 3));
            Assert.True(actualChain[3] == new Point(2, 4));
            Assert.True(actualChain[4] == new Point(1, 5));
        }
    }
}
