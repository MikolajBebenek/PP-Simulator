namespace Simulator.Maps;

public abstract class Map
{
    public int SizeX { get; }
    public int SizeY { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5 || sizeY < 5)
        {
            throw new ArgumentOutOfRangeException("Map dimensions must be at least 5x5.");
        }

        SizeX = sizeX;
        SizeY = sizeY;
    }

    public abstract bool Exist(Point p);
    public abstract Point Next(Point p, Direction d);
    public abstract Point NextDiagonal(Point p, Direction d);
    public abstract List<IMappable> At(Point point);
    public abstract List<IMappable> At(int x, int y);

}
