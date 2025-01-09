using Simulator;
using Simulator.Maps;
using System.Text;
using SimConsole;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<IMappable> items = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> positions = new() { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

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

        Console.WriteLine("Simulation finished!");
    }
}
