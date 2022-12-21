using Gomoku.Domain;
using Gomoku.Test.Infra;
using System.Collections.Generic;
using Xunit;

namespace Gomoku.Test.Tests.Chains
{
    public class VerticalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void Case1_IsValid()
        {
            var verticalChain = GetVerticalChain();

            var result = verticalChain.ConfirmPlacement(new Point(1, 5), out Chain actualChain);

            Assert.True(result);
            Assert.True(actualChain[0] == new Point(1, 5));
            Assert.True(actualChain[1] == new Point(2, 5));
            Assert.True(actualChain[2] == new Point(3, 5));
            Assert.True(actualChain[3] == new Point(4, 5));
            Assert.True(actualChain[4] == new Point(5, 5));
        }
    }
}
