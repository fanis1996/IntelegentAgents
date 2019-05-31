using System.Collections.Generic;

namespace IA.CubesOnTableProblem
{
    class CubeAction
    {
        //source and target are the tops of the towers of cubes
        //target is -1 for put_on_table and greater of -1 if its put_on_cube
        public int source, target;

        public CubeAction(int source, int target)
        {
            this.source = source;
            this.target = target;
        }

        public CubeState ResultState(CubeState state)
        {
            CubeState resultState = new CubeState(state);
            Cube c1 = resultState.towertops[source];
            resultState.towertops[source] = c1.IsOn;
            if (target == -1)
            {
                c1.IsOn = null;
                resultState.towertops.Add(c1);
            }
            else
            {
                c1.IsOn = resultState.towertops[target];
                resultState.towertops[target] = c1;
            }
            resultState.towertops.Remove(null);
            resultState.fromAction = this;
            return resultState;
        }

        public override string ToString()
        {
            if (target == source && target == -2)
                return "Initialization";
            if (target == -1)
                return "put cube " + source.ToString() + " on table";
            return "put cube " + source + " on cube" + target+" ";
        }
    }
}
