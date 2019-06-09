namespace IA.CubesOnTableProblem
{
    class CubeAction
    {
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
            if (resultState.cubes[source] != -1) resultState.towertops.Add(resultState.cubes[source]);//the cube below the source is a new top if it exists
            resultState.cubes[source] = target;
            if (target != -1) resultState.towertops.Remove(target);
            resultState.fromAction = this;
            return resultState;
        }

        public override string ToString()
        {
            if (target == source && target == -2)
                return "";
            if (target == -1)
                return "put cube " + source.ToString() + " on table";
            return "put cube " + source + " on top of cube " + target+" ";
        }
    }
}
