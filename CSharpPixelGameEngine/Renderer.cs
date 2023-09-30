namespace CSharpPixelGameEngine;

public interface IRenderer : IDisposable
{
    void PrepareDevice();
    RCode CreateDevice(List<object> parameters, bool isFullScreen, bool isVsyncEnabled);
    RCode DestroyDevice();
    void DisplayFrame();
    void PrepareDrawing();
    void SetDecalMode(DecalMode mode);
    void DrawLayerQuad(Vector2D offset, Vector2D scale, Pixel tint);
    void DrawDecal(DecalInstance decal);
    int CreateTexture(int width, int height, bool isFiltered = false, bool isClamped = true);
    void UpdateTexture(int id, Sprite sprite);
    void ReadTexture(int id, Sprite sprite);
    int DeleteTexture(int id);
    void ApplyTexture(int id);
    void UpdateViewport(Vector2D position, Vector2D size);
    void ClearBuffer(Pixel pixel, bool depth);
}

