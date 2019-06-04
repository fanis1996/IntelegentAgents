using Planner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IA.CubesOnTableProblem
{
    internal partial class CubeState : IState
    {
        public Dictionary<int,int> cubes;
        public List<int> towertops;
        public CubeAction fromAction;
        public CubeState()
        {
            cubes = new Dictionary<int, int>();
            towertops = new List<int>();
            fromAction = new CubeAction(-2, -2);
        }
        public CubeState(CubeState cs)
        {
            cubes = new Dictionary<int, int>(cs.cubes);
            towertops = new List<int>(cs.towertops);
        }
        public List<IState> AvailableMoves()
        {
            List<IState> availableMoves = new List<IState>();
            for(int i = 0; i < towertops.Count; i++)
            {
                for(int j = 0; j < towertops.Count; j++)
                {
                    if (i == j)
                    {
                        if (cubes[towertops[i]] != -1)
                        {
                            CubeAction a = new CubeAction(towertops[i], -1);
                            availableMoves.Add(a.ResultState(this));
                        }
                    }
                    else
                    {
                        CubeAction a = new CubeAction(towertops[i], towertops[j]);
                        availableMoves.Add(a.ResultState(this));
                    }
                }
            }

            return availableMoves;
        }

        public override bool Equals(object obj)
        {
            var state = obj as CubeState;
            for(int i =0; i < cubes.Count; i++)
            {
                if (cubes[i] != state.cubes[i]) return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            UInt64 hashcode = 0;
            for(int i = 0; i < cubes.Count; i++)
            {
                hashcode = (hashcode << 4) ^ (ulong)cubes[i];
            }
            return (int)hashcode;
        }

        public override string ToString()
        {
            string s = "";
            foreach (int c in towertops)
            {
                int curr = c;
                s += "[";
                while (curr != -1)
                {
                    s += " "+curr.ToString()+" ";
                    curr = cubes[curr];
                }
                s += "] ";
            }
            return s + " " + fromAction.ToString();


        }
    }
}
