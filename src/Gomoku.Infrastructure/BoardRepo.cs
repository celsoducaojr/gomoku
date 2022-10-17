using Gomoku.Domain.Enums;
using Gomoku.Domain.Repositories;
using System.Collections.Generic;

namespace Gomoku.Infrastructure
{
    public class BoardRepo : IBoardRepo
    {
        public Player Player { get; set; }

        public Dictionary<string, Player> Placements { get; set; }

        public BoardRepo()
        {
            Player = Player.One;
            Placements = new Dictionary<string, Player>();
        }
    }
}
