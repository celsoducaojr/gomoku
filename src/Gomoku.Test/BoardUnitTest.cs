using FluentAssertions;
using Gomoku.Domain;
using Gomoku.Domain.Chains;
using Gomoku.Domain.PlacementResults;
using Gomoku.Domain.Players;
using Gomoku.Domain.Repositories;
using Gomoku.Test.Infra;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Validations.Rules;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gomoku.Test
{
    public class BoardUnitTest : BaseUnitTest
    {
        [Fact]
        public void FourChain_IsValid()
        {
            var player1 = new Mock<IPlayer1>();
            player1.SetupGet(x => x.Placements)
                .Returns(new List<IChain>() {
                    GetHorizontalChain(),
                    GetVerticalChain(),
                    GetForwardDiagonalChain(),
                    GetBackwardDiagonalChain()
                });
            var board = new Board(player1.Object, new Mock<IPlayer2>().Object);

            var result = board.PlaceStone(new Point(1, 5));

            Assert.True(result is WinPlacementResult placement);
            Assert.True(((WinPlacementResult)result).Chains.Count == 4);
        }
    }
}
