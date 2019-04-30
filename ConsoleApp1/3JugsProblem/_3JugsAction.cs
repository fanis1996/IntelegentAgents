using System;

namespace IA
{
    partial class _3Jugs
    {
        public class _3JugsAction
        {
            public enum Action
            {
                init,
                fill_from,
                empty_into
            }
            private  Action action1;
            private int source, target;

            public _3JugsAction(Action action1, int source, int target)
            {
                this.action1 = action1;
                this.source = source;
                this.target = target;
            }

            public bool IsAvailable(_3JugsState state)
            {
                switch (action1)
                {
                    case Action.empty_into:
                        if (state.state[source] > 0 && Containers[target] >= state.state[target] + state.state[source])
                            return true;
                        return false;
                    case Action.fill_from:
                        if (Containers[source] > state.state[source] && state.state[target] > 0)
                            return true;
                        return false;
                    default:
                        return false;
                }
            }

            public _3JugsState resultState(_3JugsState current_state)
            {
                _3JugsState new_state = new _3JugsState(current_state.state);
                switch (action1)
                {
                    case Action.empty_into:
                        new_state.from_action = this;
                        new_state.state[target] += current_state.state[source];
                        new_state.state[source] = 0;
                        return new_state;
                    case Action.fill_from:
                        new_state.from_action = this;
                        new_state.state[source] =Math.Min(current_state.state[source] + current_state.state[target], Containers[source]);
                        new_state.state[target] = current_state.state[source] + current_state.state[target] > Containers[source] ?
                            current_state.state[source] + current_state.state[target] - Containers[source] : 0;
                        return new_state;
                    default:
                        return null;
                }

            }

            public override string ToString()
            {
                return action1.ToString() + source + target;
            }
        }
    }
}
