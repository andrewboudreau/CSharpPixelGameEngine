namespace CSharpPixelGameEngine;

public readonly struct Pixel
{
    public readonly byte R;
    public readonly byte G;
    public readonly byte B;
    public readonly byte A;

    public Pixel(byte R, byte G, byte B, byte A)
    {
        this.R = R;
        this.G = G;
        this.B = B;
        this.A = A;
    }

    public Pixel(uint n)
      : this(
          (byte)(n & 0xFF),
          (byte)((n >> 8) & 0xFF),
          (byte)((n >> 16) & 0xFF),
          (byte)((n >> 24) & 0xFF))
    {
    }

    public uint N
    {
        get => BitConverter.ToUInt32(new byte[] { R, G, B, A });
    }

    public void Deconstruct(out int R, out int G, out int B, out int A)
    {
        R = this.R;
        G = this.G;
        B = this.B;
        A = this.A;
    }

    public static Pixel operator *(Pixel p, float i)
    {
        return new Pixel(
            (byte)(p.R * i),
            (byte)(p.G * i),
            (byte)(p.B * i),
            p.A);
    }

    public static Pixel operator /(Pixel p, float i)
    {
        return new Pixel(
            (byte)(p.R / i),
            (byte)(p.G / i),
            (byte)(p.B / i),
            p.A);
    }

    public static Pixel operator +(Pixel p1, Pixel p2)
    {
        return new Pixel(
            (byte)(p1.R + p2.R),
            (byte)(p1.G + p2.G),
            (byte)(p1.B + p2.B),
            (byte)(p1.A + p2.A));
    }

    public static Pixel operator -(Pixel p1, Pixel p2)
    {
        return new Pixel(
            (byte)(p1.R - p2.R),
            (byte)(p1.G - p2.G),
            (byte)(p1.B - p2.B),
            (byte)(p1.A - p2.A));
    }

    public static Pixel operator *(Pixel p1, Pixel p2)
    {
        return new Pixel(
            (byte)(p1.R * p2.R),
            (byte)(p1.G * p2.G),
            (byte)(p1.B * p2.B),
            (byte)(p1.A * p2.A));
    }

    public Pixel Inverse()
    {
        return new Pixel(
            (byte)(255 - R),
            (byte)(255 - G),
            (byte)(255 - B),
            A);
    }

    public static Pixel Random()
        => new((uint)System.Random.Shared.Next(int.MinValue, int.MaxValue));
}
