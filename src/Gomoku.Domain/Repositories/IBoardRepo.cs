using Gomoku.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Domain.Repositories
{
    public interface IBoardRepo
    {
        Player Player { get; set; }
        Dictionary<string, Player> Placements { get; set; }
    }
}
