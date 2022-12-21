using Gomoku.Domain;
using Gomoku.Test.Infra;
using System.Collections.Generic;
using Xunit;

namespace Gomoku.Test.Tests.Chains
{
    public class HorizontalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void Case1_IsValid()
        {

            var horizontalChain = GetHorizontalChain();

            var result = horizontalChain.ConfirmPlacement(new Point(1, 5), out Chain actualChain);

            Assert.True(result);
            Assert.True(actualChain[0] == new Point(1, 1));
            Assert.True(actualChain[1] == new Point(1, 2));
            Assert.True(actualChain[2] == new Point(1, 3));
            Assert.True(actualChain[3] == new Point(1, 4));
            Assert.True(actualChain[4] == new Point(1, 5));
        }
    }
}
