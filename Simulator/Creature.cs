namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init => _name = Validator.Shortener(value, 3, 25, '#');
    }

    public int Level
    {
        get => _level;
        init => _level = Validator.Limiter(value, 1, 10);
    }

    protected Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions) =>
    directions.Select(d => Go(d)).ToArray();

    public string[] Go(string directions)
    {
        var parsedDirections = DirectionParser.Parse(directions);
        return Go(parsedDirections);
    }

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Info}";
    }

    public abstract string Greeting();

    public abstract int Power { get; }
}
