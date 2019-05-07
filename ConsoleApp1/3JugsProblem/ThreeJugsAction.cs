using System;

namespace IA
{
    public class ThreeJugsAction
        {
            public enum Action
            {
                init,
                fill_from,
                empty_into
            }
            private  Action action1;
            private int source, target;

            public ThreeJugsAction(Action action1, int source, int target)
            {
                this.action1 = action1;
                this.source = source;
                this.target = target;
            }

            public bool IsAvailable(ThreeJugsState state)
            {
                switch (action1)
                {
                    case Action.empty_into:
                        if (state.state[source] > 0 && ThreeJugsState.Containers[target] >= state.state[target] + state.state[source])
                            return true;
                        return false;
                    case Action.fill_from:
                        if (ThreeJugsState.Containers[source] > state.state[source] && state.state[target] > 0)
                            return true;
                        return false;
                    default:
                        return false;
                }
            }

            public ThreeJugsState resultState(ThreeJugsState current_state)
            {
                ThreeJugsState new_state = new ThreeJugsState(current_state.state);
                switch (action1)
                {
                    case Action.empty_into:
                        new_state.from_action = this;
                        new_state.state[target] += current_state.state[source];
                        new_state.state[source] = 0;
                        return new_state;
                    case Action.fill_from:
                        new_state.from_action = this;
                        new_state.state[source] =Math.Min(current_state.state[source] + current_state.state[target], ThreeJugsState.Containers[source]);
                        new_state.state[target] = current_state.state[source] + current_state.state[target] > ThreeJugsState.Containers[source] ?
                            current_state.state[source] + current_state.state[target] - ThreeJugsState.Containers[source] : 0;
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
