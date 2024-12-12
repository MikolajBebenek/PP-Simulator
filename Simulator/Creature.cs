namespace Simulator;

public class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init
        {
            var valueToSet = value.Trim();

            if (valueToSet.Length < 3)
                valueToSet = valueToSet.PadRight(3, '#');
            else if (valueToSet.Length > 25)
                valueToSet = valueToSet.Substring(0, 25).TrimEnd();
            if (valueToSet.Length < 3)
                valueToSet = valueToSet.PadRight(3, '#');

            if (char.IsLower(valueToSet[0]))
                valueToSet = char.ToUpper(valueToSet[0]) + valueToSet.Substring(1);

            _name = valueToSet;
        }
    }
    public int Level
    {
        get => _level;
        set => _level = Math.Clamp(value, 1, 10);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
    }

    public string Info => $"{Name} <{Level}>";

    public void SayHi()
    {
        Console.WriteLine($"Hi, I am {Name} at level {Level}!");
    }

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }
    
    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }
    
    public void Go(Direction[] directions)
    {
        foreach (var direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        var parsedDirections = DirectionParser.Parse(directions);
        Go(parsedDirections);
    }
}


