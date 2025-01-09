using Simulator;
using Simulator.Maps;

public class Simulation
{
    private int _currentMoveIndex = 0;

    public Map Map { get; }
    public List<IMappable> Items { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    public IMappable CurrentItem => Items[_currentMoveIndex % Items.Count];
    public string CurrentMoveName => Moves[_currentMoveIndex % Moves.Length].ToString().ToLower();

    public Simulation(Map map, List<IMappable> items, List<Point> positions, string moves)
    {
        if (items == null || items.Count == 0)
            throw new ArgumentException("Item list cannot be null or empty.");

        if (positions == null || positions.Count != items.Count)
            throw new ArgumentException("The number of positions must match the number of items.");

        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves sequence cannot be null or empty.");

        Map = map;
        Items = items;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < items.Count; i++)
        {
            items[i].AssignToMap(map, positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        var directions = DirectionParser.Parse(CurrentMoveName);
        if (directions.Count == 0)
            throw new InvalidOperationException("Invalid move in the sequence.");

        CurrentItem.Move(directions[0]);
        _currentMoveIndex++;

        if (_currentMoveIndex >= Moves.Length)
            Finished = true;
    }
}
