using Simulator;

class Program
{
    static void Main(string[] args)
    {
        var elf = new Elf("Legolas", 5, 3);
        var orc = new Orc("Gorbag", 7, 6);

        Console.WriteLine(elf.Greeting());
        Console.WriteLine(orc.Greeting());

        Console.WriteLine(string.Join(", ", elf.Go("LRU")));
        orc.Hunt();
        for (int i = 0; i < 5; i++)
        {
            orc.Hunt();
            Console.WriteLine(orc.Greeting());
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();

    }
}
