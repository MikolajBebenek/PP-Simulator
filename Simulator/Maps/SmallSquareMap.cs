namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException(nameof(size), "Map size must be between 5 and 20.");
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < SizeX && p.Y >= 0 && p.Y < SizeY;
    }

    public override Point Next(Point p, Direction d)
    {
        var nextPoint = p.Next(d);
        if (!Exist(nextPoint)) return p;
        return nextPoint;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var nextPoint = p.NextDiagonal(d);
        if (!Exist(nextPoint)) return p;
        return nextPoint;
    }
}
