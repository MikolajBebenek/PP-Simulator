using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name { get => _name; init => _name = Validator.Shortener(value, 3, 25, '#'); }
    public int Level { get => _level; init => _level = Validator.Limiter(value, 1, 10); }

    public Map? CurrentMap { get; private set; }
    public Point CurrentPosition { get; private set; }

    protected Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void AssignToMap(Map map, Point initialPosition)
    {
        if (!map.Exist(initialPosition))
            throw new ArgumentOutOfRangeException("Position is outside the map boundaries.");

        CurrentMap = map;
        CurrentPosition = initialPosition;
    }

    public void Move(Direction direction)
    {
        if (CurrentMap == null)
            return;

        var newPosition = CurrentMap.Next(CurrentPosition, direction);
        if (CurrentMap is SmallMap smallMap)
        {
            smallMap.Move(this, CurrentPosition, newPosition);
        }
        CurrentPosition = newPosition;
    }

    public string[] Go(Direction[] directions)
    {
        var results = new List<string>();
        foreach (var direction in directions)
        {
            Move(direction);
            results.Add($"{Name} moves {direction}");
        }
        return results.ToArray();
    }

    public abstract string Info { get; }
    public abstract string Greeting();
    public abstract int Power { get; }
}
