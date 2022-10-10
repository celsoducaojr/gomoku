using System.Collections.Generic;
using Gomoku.Domain.Enums;

namespace Gomoku.Domain.PlacementResults
{
    public class PlacementResult
    {
        public bool IsGameOver { get; } = false;
        public string Message { get; }

        public PlacementResult(Player player)
        {
            Message = $"Player {(int)player}'s turn.";
        }

        protected PlacementResult(bool isGameOver, string message)
        {
            IsGameOver = isGameOver;
            Message = message;
        }
    }
}
