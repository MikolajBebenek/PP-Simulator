namespace Simulator.Maps;

public interface IMappable
{
    string Name { get; }
    string Info { get; }
    int Power { get; }
    char Symbol { get; }
    Point CurrentPosition { get; }

    void AssignToMap(Map map, Point initialPosition);
    void Move(Direction direction);
}
