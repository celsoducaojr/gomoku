using Gomoku.Domain;
using Gomoku.Domain.ChainPatterns;
using Gomoku.Domain.IRepositories;
using Gomoku.Domain.PlacementResults;
using Gomoku.Domain.Players;
using Gomoku.Infrastructure;
using Gomoku.Test.Infra;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Gomoku.Test.Tests
{
    public class BoardUnitTest : BaseUnitTest
    {
        [Fact]
        public void FourChain_IsValid()
        {
            // Arrange
            var player1 = new Mock<IPlayer1>();
            player1.SetupGet(x => x.Placements)
                .Returns(new List<IChainPattern>() {
                    GetHorizontalChain(),
                    GetVerticalChain(),
                    GetForwardDiagonalChain(),
                    GetBackwardDiagonalChain()
                });
            var player2 = new Mock<IPlayer2>();
            player2.SetupGet(x => x.Placements)
                .Returns(new List<IChainPattern>());

            var game = new Game(player1.Object, player2.Object, Game.PlayerNumber.One);
            var gameRepo = new Mock<IGameRepository>();
            gameRepo.Setup(x => x.GetGame())
                .Returns(game);

            // Act
            var board = new Board(gameRepo.Object);

            var result = board.PlaceStone(new Point(1, 5));

            // Assert
            Assert.True(result is WinPlacementResult);
            Assert.True(((WinPlacementResult)result).Chains.Count == 4);
        }
    }
}
