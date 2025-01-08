using Simulator.Maps;
using Simulator;

public class Simulation
{
    private int _currentMoveIndex = 0;
    public Map Map { get; }
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    public Creature CurrentCreature
    {
        get
        {
            if (Creatures.Count == 0 || Finished)
                throw new InvalidOperationException("No creatures or simulation is finished.");
            return Creatures[_currentMoveIndex % Creatures.Count];
        }
    }

    public string CurrentMoveName
    {
        get
        {
            if (Moves.Length == 0 || Finished)
                throw new InvalidOperationException("No moves or simulation is finished.");
            return Moves[_currentMoveIndex % Moves.Length].ToString().ToLower();
        }
    }

    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
            throw new ArgumentException("Creature list cannot be empty.");

        if (creatures.Count != positions.Count)
            throw new ArgumentException("The number of creatures must match the number of positions.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        for (int i = 0; i < creatures.Count; i++)
        {
            creatures[i].AssignToMap(map, positions[i]);
        }
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        var directions = DirectionParser.Parse(CurrentMoveName);
        if (directions.Count == 0) 
            throw new InvalidOperationException("Invalid move in the sequence.");

        var direction = directions[0];

        CurrentCreature.Go(direction);
        _currentMoveIndex++;

        if (_currentMoveIndex >= Moves.Length)
            Finished = true;
    }
}
