using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    private string _description = "Unknown";

    public string Description
    {
        get => _description;
        init => _description = Validator.Shortener(value, 3, 15, '#');
    }

    public uint Size { get; set; } = 3;

    public string Name => Description;
    public int Power => (int)Size;

    public Map? CurrentMap { get; private set; }
    public Point CurrentPosition { get; protected set; }

    public virtual char Symbol => 'A';

    public virtual string Info => $"{Description} <{Size}>";

    public void AssignToMap(Map map, Point initialPosition)
    {
        if (!map.Exist(initialPosition))
            throw new ArgumentOutOfRangeException("Position is outside the map boundaries.");

        CurrentMap = map;
        CurrentPosition = initialPosition;
    }

    public virtual void Move(Direction direction)
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

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
}
