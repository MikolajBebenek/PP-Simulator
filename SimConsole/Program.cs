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
        string moves = "rlrluurruddurlr";

        Simulation simulation = new(map, items, positions, moves);
        SimulationHistory history = new(simulation);
        LogVisualizer visualizer = new(history);

        int turnIndex = 0;
        while (true)
        {
            visualizer.Draw(turnIndex);
            Console.WriteLine("\nUse Left/Right arrow keys to navigate turns. Press 'Q' to quit.");
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.RightArrow && turnIndex < history.TurnLogs.Count - 1)
                turnIndex++;
            else if (key == ConsoleKey.LeftArrow && turnIndex > 0)
                turnIndex--;
            else if (key == ConsoleKey.Q)
                break;
        }
    }
}
