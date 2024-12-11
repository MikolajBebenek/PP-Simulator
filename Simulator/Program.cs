namespace Simulator;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        var creature = new Creature("Fish", 7);
        creature.SayHi();
        Console.WriteLine(creature.Info);

        var animals = new Animals
        {
            Description = "Dogs"
        };
        Console.WriteLine(animals.Info);
    }
}

