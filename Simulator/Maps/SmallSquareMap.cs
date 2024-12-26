namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    /// <summary>
    /// Size of the map.
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// Constructor for SmallSquareMap.
    /// </summary>
    /// <param name="size">Size of the map (5 to 20).</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if size is not between 5 and 20.</exception>
    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Map size must be between 5 and 20.");
        }

        Size = size;
    }

    /// <summary>
    /// Check if the point exists on the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns>True if the point exists on the map; otherwise, false.</returns>
    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction to move.</param>
    /// <returns>The next point, or the same point if moving would exit the map.</returns>
    public override Point Next(Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        if (!Exist(nextPoint))
        {
            return p;
        }

        return nextPoint;
    }

    /// <summary>
    /// Next diagonal position to the point in a given direction rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction to move diagonally.</param>
    /// <returns>The next diagonal point, or the same point if moving would exit the map.</returns>
    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        if (!Exist(nextPoint))
        {
            return p;
        }

        return nextPoint;
    }
}
