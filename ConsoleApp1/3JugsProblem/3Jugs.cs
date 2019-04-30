using System;
using System.Linq;
using System.Collections.Generic;
using Planner;

namespace IA
{
    partial class _3Jugs
    {
        private static readonly _3JugsState initial = new _3JugsState(8, 0, 0)
        {
            from_action = new _3JugsAction(_3JugsAction.Action.init, -1, -1)
        };
        private static readonly _3JugsState final = new _3JugsState(4, 4, 0);
        static public void SolveProblem()
        {
            Planner<_3JugsState, _3JugsHeuristic> planner = new Planner<_3JugsState, _3JugsHeuristic>();
            List<_3JugsState> path = planner.Find_path(initial, final);
            foreach(_3JugsState s in path)
            {
                Console.WriteLine(s.ToString());
            }

        }



        static private readonly int[] Containers = { 8, 5, 3 };
    }
}
