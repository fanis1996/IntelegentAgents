
using System.Collections.Generic;

namespace Pathfinder
{
    public interface IState
    {
        List<IState> AvailableMoves();
    }
}
