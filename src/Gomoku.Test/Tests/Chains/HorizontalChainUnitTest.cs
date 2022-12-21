using Gomoku.Domain;
using Gomoku.Test.Infra;
using System.Linq;
using Xunit;

namespace Gomoku.Test.Tests.Chains
{
    public class HorizontalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void DefaultChain_IsValid()
        {

            var horizontalChain = GetHorizontalChain();
            var expectedChain = new Chain {
                new Point(1, 1),
                new Point(1, 2),
                new Point(1, 3),
                new Point(1, 4),
                new Point(1, 5)};

            var result = horizontalChain.ConfirmPlacement(new Point(1, 5), out Chain actualChain);

            Assert.True(result);
            Assert.True(Enumerable.SequenceEqual(expectedChain, actualChain));
        }
    }
}
