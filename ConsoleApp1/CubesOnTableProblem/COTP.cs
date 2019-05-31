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

        private static void Initialize()
        {
            initialState = new CubeState();
            finalState = new CubeState();

            //Inital State
            initialState.cubes.Add(0, new Cube(0, null));
            initialState.cubes.Add(1, new Cube(1, initialState.cubes[0]));
            initialState.cubes.Add(2, new Cube(2, initialState.cubes[1]));
            initialState.cubes.Add(3, new Cube(3, initialState.cubes[2]));
            initialState.cubes.Add(4, new Cube(4, initialState.cubes[3])); initialState.towertops.Add(initialState.cubes[4]);

            //Final State
            finalState.cubes.Add(0, new Cube(0, null));
            finalState.cubes.Add(1, new Cube(1, null)); finalState.towertops.Add(finalState.cubes[1]);
            finalState.cubes.Add(2, new Cube(2, null)); finalState.cubes[1].IsOn = finalState.cubes[2];
            finalState.cubes.Add(3, new Cube(3, finalState.cubes[0])); finalState.towertops.Add(finalState.cubes[3]);
            finalState.cubes.Add(4, new Cube(4, null)); finalState.towertops.Add(finalState.cubes[4]);
            //initialState.cubes.Add(0, new Cube(0, null));
            //initialState.towertops.Add(initialState.cubes[0]);
            //finalState.cubes.Add(0, new Cube(0, null));
            //finalState.towertops.Add(finalState.cubes[0]);



        }

        public static void SolveProblem()
        {
            Initialize();
            Planner.Planner<CubeState, CubeHeuristic> planner = new Planner.Planner<CubeState, CubeHeuristic>();
            List<CubeState> path = planner.Find_path(initialState, finalState);
            Console.WriteLine(path.Count);
            foreach (CubeState s in path)
            {
                Console.WriteLine(s.ToString());
            }
            Console.ReadKey();
        }
    }
}
