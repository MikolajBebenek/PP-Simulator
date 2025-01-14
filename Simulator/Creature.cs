using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name { get => _name; init => _name = Validator.Shortener(value, 3, 25, '#'); }
    public int Level { get => _level; init => _level = Validator.Limiter(value, 1, 10); }

    public Map? CurrentMap { get; private set; }
    public Point CurrentPosition { get; protected set; }

    public virtual char Symbol => 'C';

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
        CurrentMap.Add(this, initialPosition);
    }

    public void Move(Direction direction)
    {
        if (CurrentMap == null)
            throw new InvalidOperationException("Creature is not assigned to a map.");

        var newPosition = CurrentMap.Next(CurrentPosition, direction);
        CurrentMap.Move(this, CurrentPosition, newPosition);
        CurrentPosition = newPosition;
    }

    public abstract string Info { get; }
    public abstract string Greeting();
    public abstract int Power { get; }
}
