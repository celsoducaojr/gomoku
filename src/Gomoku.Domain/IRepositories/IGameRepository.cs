using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Domain.IRepositories
{
    public interface IGameRepository : IRepository
    {
        Game GetGame();

        // Add SaveChains method here...

        void Clear();
    }
}
