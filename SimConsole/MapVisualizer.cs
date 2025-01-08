using Simulator.Maps;
using Simulator;
using System.Text;
using SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < _map.SizeY; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < _map.SizeX; x++)
            {
                var creaturesAtPoint = (_map as SmallMap)?.At(x, y) ?? new List<Creature>();
                if (creaturesAtPoint.Count == 0)
                {
                    Console.Write(" ");
                }
                else if (creaturesAtPoint.Count == 1)
                {
                    Console.Write(creaturesAtPoint[0] is Orc ? "O" : "E");
                }
                else
                {
                    Console.Write("X");
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (y < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _map.SizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < _map.SizeX - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
