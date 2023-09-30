namespace CSharpPixelGameEngine;

/// <param name="Pressed">Set once during the frame the event occurs</param>
/// <param name="Released">Set once during the frame the event occurs</param>
/// <param name="Held">Set true for all frames between pressed and released events</param>
public readonly record struct HWButton(bool Pressed, bool Released, bool Held);

public class PixelGameEngine
{
    public const byte nMouseButtons = 5;
    public const byte nDefaultAlpha = 0xFF;
    public const uint nDefaultPixel = (nDefaultAlpha << 0x24);
    public const byte nTabSizeInSpaces = 4;
    public const int OLC_MAX_VERTS = 128;

    public static readonly Pixel
        Grey = new(192, 192, 192, 255),
        DarkGrey = new(128, 128, 128, 255),
        VeryDarkGrey = new(64, 64, 64, 255),
        Red = new(255, 0, 0, 255),
        DarkRed = new(128, 0, 0, 255),
        VeryDarkRed = new(64, 0, 0, 255),
        // ... other colors
        White = new(255, 255, 255, 255),
        Black = new(0, 0, 0, 255),
        Blank = new(0, 0, 0, 0);

    public PixelGameEngine()
    {
        AppName = nameof(PixelGameEngine);
    }

    public string AppName { get; init; }

    public virtual bool OnUserCreate()
    {
        return true;
    }

    public virtual bool OnUserUpdate(TimeSpan elapsedTime)
    {
        return true;
    }

    public void Draw(int x, int y, Pixel pixel)
    {
        // Pseudo drawing logic
        Console.WriteLine($"Drawing pixel at ({x}, {y}) with color ({pixel.R}, {pixel.G}, {pixel.B})");
    }
}


public interface IPixelGameEngine
{
    // Enums
    public enum ReturnCode { OK, FAIL, NO_FILE };
    public enum Key
    {
        NONE, A, B, C, D, E
    };

    public enum Mouse { LEFT = 0, RIGHT, MIDDLE };

    public enum DecalMode
    {
        NORMAL,
        ADDITIVE,
    };

    // Structures  
    public struct Pixel
    {
        //...
    };

    public struct HWButton
    {
        //...
    };

    // Main Interface
    ReturnCode Construct(
        int width, int height,
        int pixelWidth, int pixelHeight,
        bool fullScreen, bool vsync, bool cohesion);

    bool OnUserCreate();
    bool OnUserUpdate(float fElapsedTime);
    bool OnUserDestroy();

    bool IsFocused();
    HWButton GetKey(Key k);
    HWButton GetMouse(int button);
    int GetMouseX();
    int GetMouseY();
    int GetMouseWheel();

    int ScreenWidth();
    // etc...

    bool Draw(int x, int y, Pixel p);
    void DrawLine(int x1, int y1, int x2, int y2, Pixel p, uint pattern);
    // etc...

}