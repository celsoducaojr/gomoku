using Gomoku.Domain.Enums;
using Gomoku.Domain.Exceptions;
using Gomoku.Domain.PlacementResults;
using Gomoku.Domain.Players;
using Gomoku.Domain.Repositories;
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
        IPlayer1 _player1;
        IPlayer2 _player2;

        IBoardRepo _repo;

        public Board(IPlayer1 player1, IPlayer2 player2, IBoardRepo repo)
        {
            _player1 = player1;
            _player2 = player2;

            _repo = repo;
        }

        public PlacementResult PlaceStone(Point point)
        {
            if (_repo.Placements.TryGetValue($"{point.X},{point.Y}", out Player player))
            {
                throw new ConflictException($"Stone placement already exist. Moved by Player {(int)player}.");
            }
            _repo.Placements.Add($"{point.X},{point.Y}", _repo.Player);

            var placements = _repo.Player == Player.One ? _player1.Placements : _player2.Placements;
            var completedChains = new List<List<Point>>();

            foreach (var chain in placements)
            {
                if (chain.ConfirmPlacement(point, out List<Point> chains))
                {
                    completedChains.Add(chains);
                }
            }

            PlacementResult result;

            if (completedChains.Count > 0) // We have a winner
            {
                result = new WinPlacementResult(_repo.Player, completedChains);
                Clear(); 
            }
            else if (_repo.Placements.Count == 13 * 13) // It's a draw
            {
                result = new DrawPlacementResult();
                Clear(); 
            }
            else
            {
                _repo.Player = _repo.Player == Player.One ? Player.Two : Player.One; // Set turn
                result = new PlacementResult(_repo.Player);
            }

            return result;
        }

        public void Clear()
        {
            _player1.Clear();
            _player2.Clear();

            _repo.Player = Player.One;
            _repo.Placements.Clear();
        }
    }

}
