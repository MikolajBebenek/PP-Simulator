﻿using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1) Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < _map.SizeY; y++)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < _map.SizeX; x++)
            {
                var mappables = _map.At(x, y);
                if (mappables.Count == 0)
                {
                    Console.Write(" ");
                }
                else if (mappables.Count == 1)
                {
                    Console.Write(mappables[0].Symbol);
                }
                else
                {
                    Console.Write("X");
                }
                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (y < _map.SizeY - 1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _map.SizeX; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < _map.SizeX - 1) Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < _map.SizeX - 1) Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}
