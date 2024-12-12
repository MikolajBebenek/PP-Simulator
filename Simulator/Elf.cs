namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        init => _agility = Math.Clamp(value, 0, 10);
    }

    public Elf(string name = "Unknown", int level = 1, int agility = 1)
        : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi()
    {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
    }

    public void Sing()
    {
        _singCount++;
        Console.WriteLine($"{Name} is singing.");
        if (_singCount % 3 == 0)
        {
            _agility = Math.Clamp(_agility + 1, 0, 10);
        }
    }

    public override int Power => Level * 8 + Agility * 2;
}
