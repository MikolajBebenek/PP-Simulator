namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        init => _rage = Validator.Limiter(value, 0, 10);
    }

    public Orc(string name = "Unknown", int level = 1, int rage = 1)
        : base(name, level)
    {
        Rage = Validator.Limiter(rage, 0, 10);
    }

    public override string Info => $"{Name} [{Level}][{Rage}]";

    public void Hunt()
    {
        _huntCount++;
        // .WriteLine($"{Name} is hunting.");

        if (_huntCount % 2 == 0)
        {
            _rage = Validator.Limiter(_rage + 1, 0, 10);
        }
    }

    public override string Greeting() =>
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";


    public override int Power => Level * 7 + Rage * 3;
}
