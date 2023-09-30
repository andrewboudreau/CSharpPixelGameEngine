using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPixelGameEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;

//ResourceLoadStatus
public enum RCode { FAIL = 0, OK = 1, NO_FILE = -1 };


public class ResourcePack { }




public class Sprite
{
    public int Width { get; internal set; }
    public int Height { get; internal set; }
    public enum Mode { NORMAL, PERIODIC, CLAMP }
    public enum Flip { NONE = 0, HORIZ = 1, VERT = 2 }

    public Mode SampleMode { get; private set; } = Mode.NORMAL;
    internal List<Pixel> PixelData;

    // Assuming ImageLoader is another class we will port later
    public static ImageLoader Loader { get; set; }

    public Sprite()
    {
        Width = 0;
        Height = 0;
        PixelData = [];
    }

    public Sprite(string imageFile, ResourcePack? pack = null)
    {
        LoadFromFile(imageFile, pack);
    }

    public Sprite(uint width, uint height)
    {
        Width = (int)width;
        Height = (int)height;
        PixelData = new List<Pixel>((int)(width * height));
    }

    public Sprite(int width, int height) 
        : this((uint)width, (uint)height) 
    { 
    }

    // Destructor in C# (optional)
    ~Sprite()
    {
        PixelData.Clear();
    }

    // Methods
    public void SetSampleMode(Mode mode = Mode.NORMAL)
    {
        SampleMode = mode;
    }
    public Pixel GetPixel(int x, int y)
    {
        // Using switch expression for brevity
        return SampleMode switch
        {
            Mode.NORMAL =>
                (x >= 0 && x < Width && y >= 0 && y < Height) ?
                    PixelData[y * Width + x] :
                    new Pixel(0, 0, 0, 0),

            Mode.PERIODIC
                => PixelData[Math.Abs(y % Height) * Width + Math.Abs(x % Width)],

            Mode.CLAMP
                => PixelData[Math.Max(0, Math.Min(y, Height - 1)) * Width + Math.Max(0, Math.Min(x, Width - 1))],

            _ => PixelGameEngine.Blank
        };
    }

    public Pixel GetPixel(Vector2D a) // Assuming Vector2D is a struct with x and y as integers
    {
        return GetPixel(a.x, a.y);
    }

    public bool SetPixel(int x, int y, Pixel p)
    {
        if (x >= 0 && x < Width && y >= 0 && y < Height)
        {
            PixelData[y * Width + x] = p;
            return true;
        }
        return false;
    }

    public bool SetPixel(Vector2D a, Pixel p)
    {
        return SetPixel(a.x, a.y, p);
    }

    public Pixel Sample(float x, float y)
    {
        int sx = Math.Min((int)(x * Width), Width - 1);
        int sy = Math.Min((int)(y * Height), Height - 1);
        return GetPixel(sx, sy);
    }

    public Pixel Sample(Vector2D uv)  // Assuming Vector2D can also have float x, y
    {
        return Sample(uv.x, uv.y);
    }

    public Pixel SampleBL(float u, float v)
    {
        u = u * Width - 0.5f;
        v = v * Height - 0.5f;
        int x = (int)Math.Floor(u);
        int y = (int)Math.Floor(v);
        float uRatio = u - x;
        float vRatio = v - y;
        float uOpposite = 1 - uRatio;
        float vOpposite = 1 - vRatio;

        Pixel p1 = GetPixel(Math.Max(x, 0), Math.Max(y, 0));
        Pixel p2 = GetPixel(Math.Min(x + 1, Width - 1), Math.Max(y, 0));
        Pixel p3 = GetPixel(Math.Max(x, 0), Math.Min(y + 1, Height - 1));
        Pixel p4 = GetPixel(Math.Min(x + 1, Width - 1), Math.Min(y + 1, Height - 1));

        return new Pixel(
            (byte)((p1.R * uOpposite + p2.R * uRatio) * vOpposite + (p3.R * uOpposite + p4.R * uRatio) * vRatio),
            (byte)((p1.G * uOpposite + p2.G * uRatio) * vOpposite + (p3.G * uOpposite + p4.G * uRatio) * vRatio),
            (byte)((p1.B * uOpposite + p2.B * uRatio) * vOpposite + (p3.B * uOpposite + p4.B * uRatio) * vRatio),
            p1.A  // Assuming alpha remains constant
        );
    }

    public Pixel SampleBL(Vector2D uv)  // Assuming Vector2D can also have float x, y
    {
        return SampleBL(uv.x, uv.y);
    }
    public RCode LoadFromFile(string imageFile, ResourcePack? pack = null)
    {
        // Implementation to load from file will go here
        // For now, this is a stub
        return RCode.OK;  // Assuming RCode is the C# equivalent of olc::rcode
    }
    public Sprite Duplicate()
    {
        Sprite newSprite = new Sprite(Width, Height);
        newSprite.PixelData = new List<Pixel>(PixelData);
        newSprite.SampleMode = SampleMode;
        return newSprite;
    }

    public Sprite Duplicate(Vector2D pos, Vector2D size)
    {
        Sprite newSprite = new Sprite(size.x, size.y);
        for (int y = 0; y < size.y; y++)
        {
            for (int x = 0; x < size.x; x++)
            {
                newSprite.SetPixel(x, y, GetPixel(pos.x + x, pos.y + y));
            }
        }
        return newSprite;
    }
    public Vector2D Size()
    {
        return new Vector2D(Width, Height);
    }

}
