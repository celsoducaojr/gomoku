using Gomoku.Domain;
using Gomoku.Test.Infra;
using System.Linq;
using Xunit;

namespace Gomoku.Test.Tests.Chains
{
    public class VerticalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void DefaultChain_IsValid()
        {
            var verticalChain = GetVerticalChain();
            var expectedChain = new Chain {
                new Point(1, 5),
                new Point(2, 5),
                new Point(3, 5),
                new Point(4, 5),
                new Point(5, 5)};

            var result = verticalChain.ConfirmPlacement(new Point(1, 5), out Chain actualChain);

            Assert.True(result);
            Assert.True(Enumerable.SequenceEqual(expectedChain, actualChain));
        }
    }
}
