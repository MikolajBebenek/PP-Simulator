namespace Simulator.Maps;

public abstract class Map
{
    private readonly Dictionary<Point, List<IMappable>> _mappablePositions = new();

    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5x5.");
        SizeX = sizeX;
        SizeY = sizeY;
    }

    public void Add(IMappable mappable, Point point)
    {
        if (!Exist(point))
            throw new ArgumentOutOfRangeException("Position is outside the map boundaries.");

        if (!_mappablePositions.ContainsKey(point))
            _mappablePositions[point] = new List<IMappable>();

        _mappablePositions[point].Add(mappable);
    }

    public void Remove(IMappable mappable, Point point)
    {
        if (_mappablePositions.ContainsKey(point))
        {
            _mappablePositions[point].Remove(mappable);
            if (_mappablePositions[point].Count == 0)
                _mappablePositions.Remove(point);
        }
    }

    public void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public List<IMappable> At(int x, int y)
    {
        return At(new Point(x, y));
    }

    public List<IMappable> At(Point point)
    {
        return _mappablePositions.ContainsKey(point) ? _mappablePositions[point] : new List<IMappable>();
    }

    public abstract bool Exist(Point p);
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);
}
