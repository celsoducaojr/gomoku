using FluentAssertions;
using Gomoku.Domain;
using Gomoku.Domain.Chains;
using Gomoku.Domain.Repositories;
using Gomoku.Test.Infra;
using Microsoft.AspNetCore.Mvc.Versioning;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gomoku.Test.Chains
{
    public class BackwardDiagonalChainUnitTest : BaseUnitTest
    {
        [Fact]
        public void Case1_IsValid()
        {
            var chain = GetBackwardDiagonalChain();

            var result = chain.ConfirmPlacement(new Point(1, 5), out List<Point> actualChain);

            Assert.True(result);
            Assert.True(actualChain[0] == new Point(1, 5));
            Assert.True(actualChain[1] == new Point(2, 6));
            Assert.True(actualChain[2] == new Point(3, 7));
            Assert.True(actualChain[3] == new Point(4, 8));
            Assert.True(actualChain[4] == new Point(5, 9));
        }
    }
}
