using System;
using Pathfinder;

namespace IA
{
    public class ThreeJugsHeuristic : IHeuristic
        {
            public double CalculateH(IState state)
            {
                int[] s = ((ThreeJugsState)state).state, fs = ThreeJugs.final.state ;
                return Math.Sqrt(Math.Pow(s[0] - fs[0], 2) + Math.Pow(s[1] - fs[1], 2) + Math.Pow(s[2] - fs[2], 2));
            }
        }
    
}
