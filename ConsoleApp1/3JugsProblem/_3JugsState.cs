using System.Linq;
using System.Collections.Generic;
using Planner;

namespace IA
{
    partial class _3Jugs
    {
        public class _3JugsState : Planner.IState
        {
            public  int[] state;
            public _3JugsAction from_action;

            public _3JugsState(int x,int y,int z)
            {
                this.state = new int[3];
                state[0] = x;
                state[1] = y;
                state[2] = z;
            }

            public _3JugsState(int[] s)
            {
                this.state = new int[3];
                state[0] = s[0];
                state[1] = s[1];
                state[2] = s[2];
            }

            public List<IState> AvailableMoves()
            {
                List<IState> available_moves = new List<IState>();
                for (int i = 0; i < 3; i++)//source
                    for (int j = 0; j < 3; j++)//target
                    {
                        if (i == j) continue;
                        _3JugsAction empty_into = new _3JugsAction(_3JugsAction.Action.empty_into, i, j);
                        _3JugsAction fill_from = new _3JugsAction(_3JugsAction.Action.fill_from, i, j);
                        if (empty_into.IsAvailable(this)) available_moves.Add(empty_into.resultState(this));
                        if (fill_from.IsAvailable(this)) available_moves.Add(fill_from.resultState(this));
                    }
                return available_moves;

            }

            public override bool Equals(object obj)
            {
                return this.state.SequenceEqual(((_3JugsState)obj).state);
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
}
