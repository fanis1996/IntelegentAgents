using System;
using System.Collections.Generic;
using Pathfinder;

namespace IA.CubesOnTableProblem
{
    class COTP
    {
        public static CubeState initialState, finalState;
        

        public static void SolveProblem()
        {
            initialState = new CubeState();
            finalState = new CubeState();

            int c =11;

            //Inital State
            for(int i = 0; i < c; i++)
            {
                initialState.cubes[i] = i - 1;
            }
            initialState.towertops.Add(c - 1);

            //Final State
            finalState.cubes[0] = 2; finalState.towertops.Add(0);
            finalState.cubes[1] = 7;
            finalState.cubes[2] = 10;
            finalState.cubes[3] = 1;finalState.towertops.Add(3);
            finalState.cubes[4] = -1;
            finalState.cubes[5] = 6; finalState.towertops.Add(5);
            finalState.cubes[6] = 4;
            finalState.cubes[7] = -1;
            finalState.cubes[8] = 9; finalState.towertops.Add(8);
            finalState.cubes[9] = -1;
            finalState.cubes[10] = -1;





            Pathfinder<CubeState, CubeHeuristic> p = new Pathfinder<CubeState, CubeHeuristic>();
            List<CubeState> path = p.Find_path(initialState, finalState);
            foreach (CubeState s in path)
            {
                Console.WriteLine(s.ToString());
            }
            Console.ReadKey();
        }
    }
}
