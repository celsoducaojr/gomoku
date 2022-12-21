using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomoku.Domain;
using Gomoku.Domain.IRepositories;

namespace Gomoku.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        readonly Game _game;

        public GameRepository(Game game) 
        {
            _game = game;
        }

        public Game GetGame()
        {
            return _game;
        }

        public void Clear()
        {
            _game.Clear();

            // Save data changes
        }

    }
}
