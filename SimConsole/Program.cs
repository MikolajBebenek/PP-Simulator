using Simulator;
using Simulator.Maps;
using SimConsole;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new(8);
        List<IMappable> items = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Rabbits", Size = 6 },
            new Birds { Description = "Eagles", Size = 4, CanFly = true },
            new Birds { Description = "Ostriches", Size = 5, CanFly = false }
        };
        List<Point> positions = new()
        {
            new(2, 2),
            new(3, 1),
            new(3, 2),
            new(6, 5),
            new(5, 5)
        };
        string moves = "dlrludlruddurlr";

        Simulation simulation = new(map, items, positions, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine($"Current Item: {simulation.CurrentItem.Name}");
            Console.WriteLine($"Current Move: {simulation.CurrentMoveName}");
            simulation.Turn();
            Console.ReadKey();
        }

        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
