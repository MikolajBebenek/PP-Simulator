namespace Simulator.Maps;

public interface IMappable
{
    string Name { get; }
    string Info { get; }
    int Power { get; }

    void AssignToMap(Map map, Point initialPosition);
    void Move(Direction direction);
    Point CurrentPosition { get; }
}
