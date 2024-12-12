namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        set
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

    protected Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public abstract void SayHi();
    public abstract int Power { get; }
}
