namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        private set => _agility = Validator.Limiter(value, 0, 10);
    }

    public Elf(string name = "Unknown", int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = Validator.Limiter(agility, 0, 10);
    }

    public override string Info => $"{Name} [{Level}][{Agility}]";

    public void Sing()
    {
        _singCount++;

        if (_singCount % 3 == 0)
        {
            Agility = Validator.Limiter(Agility + 1, 0, 10);
        }
    }

    public override string Greeting() =>
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

    public override int Power => Level * 8 + Agility * 2;

    public string[] Go(Direction[] directions)
    {
        return base.Go(directions);
    }
}
