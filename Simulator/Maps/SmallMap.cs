namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly Dictionary<Point, List<Creature>> _creaturePositions = new();

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public void Add(Creature creature, Point point)
    {
        if (!Exist(point)) throw new ArgumentOutOfRangeException();

        if (!_creaturePositions.ContainsKey(point))
        {
            _creaturePositions[point] = new List<Creature>();
        }

        _creaturePositions[point].Add(creature);
    }

    public void Remove(Creature creature, Point point)
    {
        if (_creaturePositions.ContainsKey(point))
        {
            _creaturePositions[point].Remove(creature);
            if (_creaturePositions[point].Count == 0)
            {
                _creaturePositions.Remove(point);
            }
        }
    }

    public void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }

    public List<Creature> At(Point point)
    {
        return _creaturePositions.ContainsKey(point) ? _creaturePositions[point] : new List<Creature>();
    }

    public List<Creature> At(int x, int y)
    {
        return At(new Point(x, y));
    }
}

