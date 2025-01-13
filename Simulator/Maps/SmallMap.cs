namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _mappablePositions = new();

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public void Add(IMappable mappable, Point point)
    {
        if (!Exist(point)) throw new ArgumentOutOfRangeException();

        if (!_mappablePositions.ContainsKey(point))
        {
            _mappablePositions[point] = new List<IMappable>();
        }

        _mappablePositions[point].Add(mappable);
    }

    public void Remove(IMappable mappable, Point point)
    {
        if (_mappablePositions.ContainsKey(point))
        {
            _mappablePositions[point].Remove(mappable);
            if (_mappablePositions[point].Count == 0)
            {
                _mappablePositions.Remove(point);
            }
        }
    }

    public override void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public override List<IMappable> At(Point point)
    {
        return _mappablePositions.ContainsKey(point) ? _mappablePositions[point] : new List<IMappable>();
    }

    public override List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}
