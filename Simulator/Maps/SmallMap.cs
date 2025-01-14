namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _mappablePositions = new();

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }
}
