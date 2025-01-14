using Simulator;
using Simulator.Maps;

namespace SimConsole;

/// <summary>
/// Visualizer for displaying simulation history in the console.
/// </summary>
internal class LogVisualizer
{
    private SimulationHistory Log { get; }

    public LogVisualizer(SimulationHistory log)
    {
        Log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= Log.TurnLogs.Count)
            throw new ArgumentOutOfRangeException(nameof(turnIndex), "Invalid turn index.");

        var turnLog = Log.TurnLogs[turnIndex];

        Console.Clear();
        Console.WriteLine($"Turn {turnIndex}:");
        Console.WriteLine($"Moving: {turnLog.Mappable}");
        Console.WriteLine($"Move: {turnLog.Move}");
        Console.WriteLine();

        Console.Write(Box.TopLeft);
        for (int x = 0; x < Log.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < Log.SizeX - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < Log.SizeY; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < Log.SizeX; x++)
            {
                var point = new Point(x, y);
                if (turnLog.Symbols.ContainsKey(point))
                {
                    Console.Write(turnLog.Symbols[point]);
                }
                else
                {
                    Console.Write(" ");
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (y < Log.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < Log.SizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < Log.SizeX - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < Log.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < Log.SizeX - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
