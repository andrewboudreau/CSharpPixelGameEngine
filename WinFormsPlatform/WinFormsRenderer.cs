using CSharpPixelGameEngine;

namespace WinFormsPlatform;

public class WinFormsRenderer : IRenderer
{
    private readonly Form gameForm;
    private Graphics graphics;

    private DecalMode currentDecalMode = DecalMode.Normal;

    public WinFormsRenderer(Form form)
    {
        gameForm = form ?? throw new ArgumentNullException(nameof(form));
        graphics = gameForm.CreateGraphics();
    }
    
    public void PrepareDevice()
    {
        // Initialize the graphics device, if needed
    }

    public RCode CreateDevice(List<object> parameters, bool isFullScreen, bool isVsyncEnabled)
    {
        // Set up the graphics device parameters, such as screen size, vsync, etc.
        return RCode.OK;
    }

    public RCode DestroyDevice()
    {
        // Cleanup resources
        graphics.Dispose();
        return RCode.OK;
    }

    public void Dispose()
    {
        // Implement IDisposable to cleanup resources
        DestroyDevice();
    }

    public void DisplayFrame()
    {
        // Flush the graphics to display the frame, if needed
    }
    public void PrepareDrawing()
    {
        // Prepare the graphics object for drawing
    }

    public void SetDecalMode(DecalMode mode)
    {
        // Set the decal rendering mode
        currentDecalMode = mode;
    }

    public void DrawLayerQuad(Vector2D offset, Vector2D scale, Pixel tint)
    {
        // Draw a quad layer at the given offset and scale, tinted with the specified color
        using (var brush = new SolidBrush(Color.FromArgb(tint.A, tint.R, tint.G, tint.B)))
        {
            graphics.FillRectangle(brush, (float)offset.x, (float)offset.y, (float)scale.x, (float)scale.y);
        }
    }
    public void DrawDecal(DecalInstance decal)
    {
        // Draw a decal based on its instance properties
    }

    public int CreateTexture(int width, int height, bool isFiltered = false, bool isClamped = true)
    {
        // Create a new texture and return its ID
        return 0; // Placeholder
    }

    public void UpdateTexture(int id, Sprite sprite)
    {
        // Update an existing texture with a new sprite
    }

    public void ReadTexture(int id, Sprite sprite)
    {
        // Read texture data into a sprite
    }

    public int DeleteTexture(int id)
    {
        // Delete a texture by its ID
        return 0; // Placeholder
    }

    public void ApplyTexture(int id)
    {
        // Apply a texture by its ID for subsequent drawing
    }

    public void UpdateViewport(Vector2D position, Vector2D size)
    {
        // Update the viewport dimensions
    }

    public void ClearBuffer(Pixel pixel, bool depth)
    {
        // Clear the frame buffer and optionally the depth buffer
        graphics.Clear(Color.FromArgb(pixel.A, pixel.R, pixel.G, pixel.B));
    }
}