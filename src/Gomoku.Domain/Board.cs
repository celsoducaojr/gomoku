using Gomoku.Domain.Exceptions;
using Gomoku.Domain.IRepositories;
using Gomoku.Domain.PlacementResults;
using System.Collections.Generic;

namespace Gomoku.Domain
{
    public interface IBoard
    {
        PlacementResult PlaceStone(Point point);

        void Clear();
    }

    public class Board : IBoard
    {
        readonly IGameRepository _repository;

        public Board(IGameRepository repository)
        {
            _repository = repository;
        }

        public PlacementResult PlaceStone(Point point)
        {
            var game = _repository.Get();
            var collectivePoints = game.GetCollectivePoints();

            // Validate duplicate placement
            if (collectivePoints.Contains(point))
            {
                throw new ConflictException($"Stone placement already exist.");
            }

            // Set player
            var player = game.GetCurrentPlayer();
            var placements = player.Placements;
            var chainedPlacement = new ChainList();

            foreach (var chain in placements)
            {
                if (chain.ConfirmPlacement(point, out Chain chains))
                {
                    chainedPlacement.Add(chains);
                }
            }

            // Validate placement result
            PlacementResult result;

            if (chainedPlacement.Count > 0) // We have a winner
            {
                result = new WinPlacementResult(game.CurrentPlayerNumber, chainedPlacement);
                Clear(); 
            }
            else if (collectivePoints.Count == 13 * 13) // It's a draw (15 x 15 board)
            {
                result = new DrawPlacementResult();
                Clear();
            }
            else // Set next turn
            {
                game.SetNextTurn();
                result = new PlacementResult(game.CurrentPlayerNumber);
            }

            // Save changes
            _repository.Save(game);

            return result;
        }

        public void Clear()
        {
            _repository.Clear();
        }
    }

}
