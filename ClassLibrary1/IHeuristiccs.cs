namespace Pathfinder
{
    public interface IHeuristic
    {
        double CalculateH(IState state);
    }
}
