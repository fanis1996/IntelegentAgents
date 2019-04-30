using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    public interface IState
    {
        List<IState> AvailableMoves();
    }
}
