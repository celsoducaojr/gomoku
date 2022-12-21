using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Domain.IRepositories
{
    public interface IGameRepository : IRepository
    {
        Game Get();

        void Save(Game game);

        void Clear();
    }
}
