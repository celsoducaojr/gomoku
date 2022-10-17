using Gomoku.Domain.Chains;
using Gomoku.Domain.Enums;
using Gomoku.Domain.Exceptions;
using Gomoku.Domain.PlacementResults;
using Gomoku.Domain.Players;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

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

        Player _player;
        Dictionary<string, Player> _placements;

        public Board(IPlayer1 player1, IPlayer2 player2)
        {
            _player1 = player1;
            _player2 = player2;

            _player = Player.One;
            _placements = new Dictionary<string, Player>();
        }

        public PlacementResult PlaceStone(Point point)
        {
            if (_placements.TryGetValue($"{point.X},{point.Y}", out Player player))
            {
                throw new ConflictException($"Stone placement already exist. Moved by Player {(int)player}.");
            }
            _placements.Add($"{point.X},{point.Y}", _player);

            var placements = _player == Player.One ? _player1.Placements : _player2.Placements;
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
                result = new WinPlacementResult(_player, completedChains);
                Clear(); 
            }
            else if (_placements.Count == 13 * 13) // It's a draw
            {
                result = new DrawPlacementResult();
                Clear(); 
            }
            else
            {
                _player = _player == Player.One ? Player.Two : Player.One; // Set turn
                result = new PlacementResult(_player);
            }

            return result;
        }

        public void Clear()
        {
            _player1.Clear();
            _player2.Clear();

            _player = Player.One;
            _placements.Clear();
        }
    }

}
