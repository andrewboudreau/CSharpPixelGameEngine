using System.Drawing;

namespace CSharpPixelGameEngine;

public struct Vector2D
{
    public int x, y;

    public Vector2D(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    // Implicit conversion from Point to Vector2D
    public static implicit operator Vector2D(Point point)
    {
        return new Vector2D(point.X, point.Y);
    }

    // Implicit conversion from Vector2D to Point
    public static implicit operator Point(Vector2D vector)
    {
        return new Point(vector.x, vector.y);
    }

    // Implicit conversion from Size to Vector2D
    public static implicit operator Vector2D(Size size)
    {
        return new Vector2D(size.Width, size.Height);
    }

    // Implicit conversion from Vector2D to Size
    public static implicit operator Size(Vector2D vector)
    {
        return new Size(vector.x, vector.y);
    }
}

public readonly struct Vf2d
{
    public float X { get; }
    public float Y { get; }

    public Vf2d(float x, float y)
    {
        X = x;
        Y = y;
    }

    // Operator overloads
    public static Vf2d operator +(Vf2d a, Vf2d b) => new Vf2d(a.X + b.X, a.Y + b.Y);

    // Additional methods
}


public readonly struct Vi2d
{
    public int X { get; }
    public int Y { get; }

    public Vi2d(int x, int y)
    {
        X = x;
        Y = y;
    }

    // You can add operator overloads for ease of use
    public static Vi2d operator +(Vi2d a, Vi2d b) => new Vi2d(a.X + b.X, a.Y + b.Y);

    // Any additional methods to manipulate or query the vector
}
