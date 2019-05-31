using System;
using System.Collections.Generic;

namespace IA.CubesOnTableProblem
{
    public class Cube :IComparable
    {
        public Cube(Cube c)
        {
            Id = c.Id;
            IsOn = c.IsOn != null ? new Cube(c.IsOn) : null;
        }

        public Cube(int id, Cube isOn)
        {
            Id = id;
            IsOn = isOn;
        }

        public int Id;
        public Cube IsOn;

        public override bool Equals(object obj)
        {
            var cube = obj as Cube;
            if (cube != null && Id == cube.Id)
            {
                if (IsOn == null && cube.IsOn == null)
                    return true;
                if (IsOn != null && cube.IsOn != null && IsOn.Id == cube.IsOn.Id)
                    return true;
            }
            return cube != null && Id == cube.Id &&((IsOn == null && cube.IsOn == null)|| (IsOn != null && cube.IsOn != null && IsOn.Id == cube.IsOn.Id));


        }

        public override int GetHashCode()
        {
            return Id<<4^(IsOn!=null?IsOn.Id:0);
        }

        public int CompareTo(object obj)
        {
            return Id.CompareTo((obj as Cube).Id);
        }

        public override string ToString()
        {
            return String.Format(@"({0},{1})\n", Id, IsOn != null ? IsOn.Id.ToString(): "table");
        }
    }
}
