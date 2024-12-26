﻿namespace Simulator;
using Simulator.Maps;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        {
            Point p = new(10, 25);
            Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
            Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 24)
            Lab5b();
        }
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3),
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
    static void Lab5a()
    {
        Console.WriteLine("Rectangle Tests\n");

        // Testowanie konstrukcji prostokąta z luźnych współrzędnych
        try
        {
            var rect1 = new Rectangle(10, 5, 15, 10);
            Console.WriteLine($"Created rectangle: {rect1}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Testowanie współrzędnych w złej kolejności
        try
        {
            var rect2 = new Rectangle(15, 10, 10, 5);
            Console.WriteLine($"Created rectangle with swapped coordinates: {rect2}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Testowanie prostokąta z punktów
        try
        {
            var rect3 = new Rectangle(new Point(20, 25), new Point(25, 30));
            Console.WriteLine($"Created rectangle from points: {rect3}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Testowanie prostokąta liniowego
        try
        {
            var rect4 = new Rectangle(5, 5, 5, 10);
            Console.WriteLine($"Created rectangle: {rect4}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Testowanie metody Contains
        var rect5 = new Rectangle(10, 10, 20, 20);
        var pointInside = new Point(15, 15);
        var pointOutside = new Point(25, 25);

        Console.WriteLine($"Rectangle: {rect5}");
        Console.WriteLine($"Contains {pointInside}: {rect5.Contains(pointInside)}");
        Console.WriteLine($"Contains {pointOutside}: {rect5.Contains(pointOutside)}");
    }
    static void Lab5b()
    {
        Console.WriteLine("Testing SmallSquareMap\n");

        try
        {
            // Tworzenie mapy o rozmiarze 10
            var map = new SmallSquareMap(10);
            Console.WriteLine($"Created map with size: {map.Size}");

            // Testowanie punktów
            Point p1 = new(5, 5);
            Point p2 = new(15, 15);

            Console.WriteLine($"Point {p1} exists: {map.Exist(p1)}"); // True
            Console.WriteLine($"Point {p2} exists: {map.Exist(p2)}"); // False

            // Testowanie ruchu
            Console.WriteLine($"Next from {p1} to the right: {map.Next(p1, Direction.Right)}"); // (6, 5)
            Console.WriteLine($"Next from {p1} upwards: {map.Next(p1, Direction.Up)}"); // (5, 4)
            Console.WriteLine($"Next from {p1} diagonally right: {map.NextDiagonal(p1, Direction.Right)}"); // (6, 4)

            // Próba stworzenia mapy z nieprawidłowym rozmiarem
            try
            {
                var invalidMap = new SmallSquareMap(3);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
