using Simulator.Maps;
using Simulator;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        for (int y = 0; y < _map.SizeY; y++)
        {
            for (int x = 0; x < _map.SizeX; x++)
            {
                var mappables = _map.At(x, y);
                if (mappables.Count == 1)
                    Console.Write(mappables[0] is Elf ? "E" : "O");
                else if (mappables.Count > 1)
                    Console.Write("X");
                else
                    Console.Write(".");
            }
            Console.WriteLine();
        }
    }
}
