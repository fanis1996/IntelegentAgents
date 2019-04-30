using System;
using Planner;

namespace IA
{
    partial class _3Jugs
    {
        public class _3JugsHeuristic : IHeuristic
        {
            public double CalculateH(IState state)
            {
                int[] s = ((_3JugsState)state).state, fs = _3Jugs.final.state ;
                return Math.Sqrt(Math.Pow(s[0] - fs[0], 2) + Math.Pow(s[1] - fs[1], 2) + Math.Pow(s[2] - fs[2], 2));
            }
        }
    }
}
