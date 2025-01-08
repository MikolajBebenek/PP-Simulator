using Simulator;
using Simulator.Maps;
using SimConsole;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<Creature> creatures = new() { new Orc("Gorbag"), new Elf("Elandor") };
        List<Point> positions = new() { new(2, 2), new(3, 1) };
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, positions, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
            while (!simulation.Finished)
            {
                Console.Clear();
                mapVisualizer.Draw();

                Console.WriteLine($"Turn {simulation.CurrentMoveName.ToUpper()}:");
                Console.WriteLine($"{simulation.CurrentCreature.GetType().Name.ToUpper()}: {simulation.CurrentCreature.Name} [{simulation.CurrentCreature.Level}][{simulation.CurrentCreature.Power}] " +
                                  $"({simulation.CurrentCreature.CurrentPosition.X}, {simulation.CurrentCreature.CurrentPosition.Y}) " +
                                  $"goes {simulation.CurrentMoveName}:");

                simulation.Turn();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
