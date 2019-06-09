using System;
using System.Collections.Generic;
using System.Linq;
using C5;

namespace Pathfinder
{
    public class Pathfinder<S,H> 
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
                Node other = obj as Node;
                if (state.Equals(other.state))
                {
                    return g.CompareTo(other.g);
                }
                return f.CompareTo(other.f) ==0? g.CompareTo(other.g) : f.CompareTo(other.f);
            }
        }

        public List<S> Find_path(S start, S end)
        {
            System.Collections.Generic.HashSet<S> closedSet = new System.Collections.Generic.HashSet<S>();
            IntervalHeap<Node> openSet = new IntervalHeap<Node>();
            Node curr = new Node(start, null);
            while (!curr.state.Equals(end))
            {
                if (!closedSet.Contains(curr.state))
                {
                    foreach (S state in curr.state.AvailableMoves())
                    {
                        if (closedSet.Contains(state)) continue;
                        openSet.Add(new Node(state, curr));
                    }
                    closedSet.Add(curr.state);
                }
                curr = openSet.DeleteMin();

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
