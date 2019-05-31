using Planner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IA.CubesOnTableProblem
{
    internal partial class CubeState : IState
    {
        public SortedList<int,Cube> cubes;
        public List<Cube> towertops;
        public CubeAction fromAction;
        public CubeState()
        {
            cubes = new SortedList<int, Cube>();
            towertops = new List<Cube>();
        }
        public CubeState(CubeState cs)
        {
            cubes = new SortedList<int, Cube>();
            towertops = new List<Cube>();
            foreach(Cube cube in cs.towertops)
            {
                Cube curr = new Cube(cube);
                towertops.Add(curr);
                while (curr != null)
                {
                    cubes.Add(curr.Id, curr);
                    curr = curr.IsOn;
                }
            }
        }
        public List<IState> AvailableMoves()
        {
            List<IState> availableMoves = new List<IState>();
            for(int i =0;i<towertops.Count;i++)
            {
                for (int j = 0; j < towertops.Count; j++)
                {
                    if(i == j && towertops[i].IsOn != null)
                    {
                        CubeAction a = new CubeAction(i, -1);
                        availableMoves.Add(a.ResultState(this));
                    }
                    else if (i != j)
                    {
                        CubeAction a = new CubeAction(i, j);
                        availableMoves.Add(a.ResultState(this));
                    }
                }
            }
            return availableMoves;
        }

        public override bool Equals(object obj)
        {

            return cubes.SequenceEqual((obj as CubeState).cubes);
        }

        public override int GetHashCode()
        {
            var hash = -146750;
            foreach (KeyValuePair<int, Cube> pair in cubes)
                hash = hash^ pair.Value.GetHashCode() ;
            return hash;
        }

        public override string ToString()
        {
            string s="";
            foreach(Cube c in towertops)
            {
                Cube curr = c;
                s += "[";
                while (curr != null)
                {
                    s += curr.ToString() + ", ";
                    curr = curr.IsOn;
                }
                s += "] ";
            }
            return s+" "+fromAction.ToString();


        }
    }
}
