using System;

namespace CSharpPixelGameEngine;


public class Example : PixelGameEngine
{
    public Example()
    {
        AppName = "Example";
    }

    public override bool OnUserCreate()
    {
        // Initialization logic
        return true;
    }

    public override bool OnUserUpdate(TimeSpan elapsedTime)
    {
        for (int x = 0; x < 256; x++)
        {
            for (int y = 0; y < 240; y++)
            {
                Draw(x, y, Pixel.Random());
            }
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Example example = new();
        if (example.OnUserCreate())
        {
            example.OnUserUpdate(TimeSpan.Zero);
        }
    }
}
