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

    public abstract string Info { get; }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {Info}";
    }

    public abstract void SayHi();

    public abstract int Power { get; }
}
