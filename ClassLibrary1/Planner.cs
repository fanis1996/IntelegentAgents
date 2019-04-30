using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planner
{
    public class Planner<S,H> 
        where S : IState
        where H:IHeuristic,new()
    {
        
        protected class Node:IComparable
        {
            static private H Heuristic = new H();
            public double f, g, h;
            public Node parent;
            public S state;
            public Node() { }
            public Node(S s, Node p)
            {
                parent = p;
                state = s;
                if(p!=null)
                    g = parent.g + 1;
                h = Heuristic.CalculateH(state);
                f = g + h;
            }

            public int CompareTo(object obj)
            {
                return f.CompareTo(((Node)obj).f);
            }

        }

        public List<S> Find_path(S start, S end)
        {
            Dictionary<S, Node> closedSet = new Dictionary<S, Node>();
            SortedSet<Node> openSet = new SortedSet<Node>();
            Node curr = new Node(start, null);
            while (!curr.state.Equals(end))
            {
                if (!closedSet.ContainsKey(curr.state))
                {
                    foreach (S state in curr.state.AvailableMoves())
                    {
                        openSet.Add(new Node(state, curr));
                    }
                    Node test = new Node();
                    if (!closedSet.TryGetValue(curr.state, out test) ^ ((test != null) && curr.g < test.g))
                            closedSet[curr.state] = curr;
                }
                curr = openSet.Min;
                openSet.Remove(curr);
            }

            Stack<S> stack = new Stack<S>();
            while (curr!=null)
            {
                stack.Push(curr.state);
                curr = curr.parent;
            } 
            return stack.ToList<S>();
            
        }
    }
}
