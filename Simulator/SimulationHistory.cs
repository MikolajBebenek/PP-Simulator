using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new List<SimulationTurnLog>();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        // Store initial positions as the first log.
        var initialSymbols = new Dictionary<Point, char>();
        foreach (var item in _simulation.Items)
        {
            initialSymbols[item.CurrentPosition] = item.Symbol;
        }
        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = "Start",
            Move = "None",
            Symbols = initialSymbols
        });

        // Iterate through simulation turns.
        while (!_simulation.Finished)
        {
            var currentSymbols = new Dictionary<Point, char>();
            foreach (var item in _simulation.Items)
            {
                currentSymbols[item.CurrentPosition] = item.Symbol;
            }

            TurnLogs.Add(new SimulationTurnLog
            {
                Mappable = _simulation.CurrentItem.ToString(),
                Move = _simulation.CurrentMoveName,
                Symbols = currentSymbols
            });

            _simulation.Turn();
        }
    }
}
