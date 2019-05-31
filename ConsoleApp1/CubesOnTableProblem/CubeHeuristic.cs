using Planner;

namespace IA.CubesOnTableProblem
{
    class CubeHeuristic : IHeuristic
    {
        public double CalculateH(IState state)
        {
            int h = 0;
            CubeState current_state = state as CubeState;
            for(int i = 0; i < current_state.towertops.Count; i++)
            {
                h += current_state.cubes[i].Equals(COTP.finalState.cubes[i]) ? 0 : 1;
            }
            return h/2;
        }
    }
}
