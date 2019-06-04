using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA.CubesOnTableProblem
{
    class COTP
    {
        public static CubeState initialState, finalState;
        

        public static void SolveProblem()
        {
            initialState = new CubeState();
            finalState = new CubeState();

            int c =9;

            //Inital State
            for(int i = 0; i < c; i++)
            {
                initialState.cubes[i] = i - 1;
            }
            initialState.towertops.Add(c - 1);

            //Final State
            finalState.cubes[0] = 2; finalState.towertops.Add(0);
            finalState.cubes[1] = 7;
            finalState.cubes[2] = 8;
            finalState.cubes[3] = 1;finalState.towertops.Add(3);
            finalState.cubes[4] = -1;
            finalState.cubes[5] = 6; finalState.towertops.Add(5);
            finalState.cubes[6] = 4;
            finalState.cubes[7] = -1;
            finalState.cubes[8] = -1;





            Planner.Planner<CubeState, CubeHeuristic> planner = new Planner.Planner<CubeState, CubeHeuristic>();
            List<CubeState> path = planner.Find_path(initialState, finalState);
            foreach (CubeState s in path)
            {
                Console.WriteLine(s.ToString());
            }
            Console.ReadKey();
        }
    }
}
