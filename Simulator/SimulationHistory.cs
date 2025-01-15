using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public List<IMappable> Items => _simulation.Items;
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
        var initialSymbols = new Dictionary<Point, List<char>>();
        foreach (var item in _simulation.Items)
        {
            if (!initialSymbols.ContainsKey(item.CurrentPosition))
                initialSymbols[item.CurrentPosition] = new List<char>();

            initialSymbols[item.CurrentPosition].Add(item.Symbol);
        }
        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = "Start",
            Move = "None",
            Symbols = initialSymbols
        });

        while (!_simulation.Finished)
        {
            var currentSymbols = new Dictionary<Point, List<char>>();
            foreach (var item in _simulation.Items)
            {
                if (!currentSymbols.ContainsKey(item.CurrentPosition))
                    currentSymbols[item.CurrentPosition] = new List<char>();

                currentSymbols[item.CurrentPosition].Add(item.Symbol);
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
