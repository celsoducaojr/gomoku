using Gomoku.Domain.Players;
using System.Collections.Generic;
using System.Linq;

namespace Gomoku.Domain
{
    public class Game
    {
        public enum PlayerNumber
        {
            One = 1,
            Two = 2,
        }

        internal IPlayer1 Player1 { get; set; }
        internal IPlayer2 Player2 { get; set; }
        internal PlayerNumber CurrentPlayerNumber { get; set; }

        public Game(IPlayer1 player1, IPlayer2 player2, 
            PlayerNumber currentPlayerNumber =  PlayerNumber.One)
        {
            Player1 = player1;
            Player2 = player2;

            CurrentPlayerNumber = currentPlayerNumber;
        }

        public List<Point> GetCollectivePoints()
        {
            var points = new HashSet<Point>();

            foreach (var placement in Player1.Placements)
            {
                foreach (var chain in placement.Chains) 
                    foreach (var point in chain)
                        points.Add(point);
            }

            foreach (var placement in Player2.Placements)
            {
                foreach (var chain in placement.Chains)
                    foreach (var point in chain)
                        points.Add(point);
            }

            return points.ToList();
        }

        public IPlayer GetCurrentPlayer()
        {
            return CurrentPlayerNumber == PlayerNumber.One ? Player1 : Player2;
        }

        public void SetNextTurn()
        {
            CurrentPlayerNumber = CurrentPlayerNumber == PlayerNumber.One ? PlayerNumber.Two : PlayerNumber.One;
        }

        public void Clear()
        {
            Player1.Clear();
            Player2.Clear();

            CurrentPlayerNumber = PlayerNumber.One;
        }
    }
}
