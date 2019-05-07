using System.Linq;
using System.Collections.Generic;
using Planner;
using System;

namespace IA
{
    public class ThreeJugsState : Planner.IState
        {
        static public readonly int[] Containers = { 8, 5, 3 };
        public  int[] state;
            public ThreeJugsAction from_action;

            public ThreeJugsState(int x,int y,int z)
            {
            this.state = new int[] { x, y, z };
            }

            public ThreeJugsState(int[] s)
            {
            this.state = new int[3];
            Array.Copy(s, state, 3);
            }

            public List<IState> AvailableMoves()
            {
                List<IState> available_moves = new List<IState>();
                for (int i = 0; i < 3; i++)//source
                    for (int j = 0; j < 3; j++)//target
                    {
                        if (i == j) continue;
                        ThreeJugsAction empty_into = new ThreeJugsAction(ThreeJugsAction.Action.empty_into, i, j);
                        ThreeJugsAction fill_from = new ThreeJugsAction(ThreeJugsAction.Action.fill_from, i, j);
                        if (empty_into.IsAvailable(this)) available_moves.Add(empty_into.resultState(this));
                        if (fill_from.IsAvailable(this)) available_moves.Add(fill_from.resultState(this));
                    }
                return available_moves;

            }

            public override bool Equals(object obj)
            {
                return this.state.SequenceEqual(((ThreeJugsState)obj).state);
            }

            public override int GetHashCode()
            {
                return 259708774 + EqualityComparer<int[]>.Default.GetHashCode(state);
            }

            public override string ToString()
            {
                return state[0] + " " + state[1] + " " + state[2] + " "+ from_action.ToString();
            }
        }
    
}
