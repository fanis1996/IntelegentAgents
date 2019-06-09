using System;
using System.Collections.Generic;
using Pathfinder;

namespace IA
{
    partial class ThreeJugs
    {
        private static readonly ThreeJugsState initial = new ThreeJugsState(8, 0, 0)
        {
            from_action = new ThreeJugsAction(ThreeJugsAction.Action.init, -1, -1)
        };
        public static readonly ThreeJugsState final = new ThreeJugsState(4, 4, 0);
        static public void SolveProblem()
        {
            Pathfinder<ThreeJugsState, ThreeJugsHeuristic> p = new Pathfinder<ThreeJugsState, ThreeJugsHeuristic>();
            List<ThreeJugsState> path = p.Find_path(initial, final);
            foreach(ThreeJugsState s in path)
            {
                Console.WriteLine(s.ToString());
            }

        }



        
    }
}
