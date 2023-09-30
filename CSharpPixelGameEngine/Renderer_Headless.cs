using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Drawing;

namespace CSharpPixelGameEngine;

// Headless Renderer
public class Renderer_Headless : IRenderer
{
    public virtual void PrepareDevice() { }
    public virtual RCode CreateDevice(object[] paramsObj, bool bFullScreen, bool bVSYNC) => RCode.OK;
    public virtual RCode DestroyDevice() => RCode.OK;
    public virtual void DisplayFrame() { }
    public virtual void PrepareDrawing() { }
    public virtual void SetDecalMode(DecalMode mode) { }
    public virtual void DrawLayerQuad(PointF offset, PointF scale, Pixel tint) { }
    public virtual void DrawDecal(DecalInstance decal) { }
    public virtual int CreateTexture(int width, int height, bool filtered = false, bool clamp = true) => 1;
    public virtual void UpdateTexture(int id, Sprite spr) { }
    public virtual void ReadTexture(int id, Sprite spr) { }
    public virtual int DeleteTexture(int id) => 1;
    public virtual void ApplyTexture(int id) { }
    public virtual void UpdateViewport(Vector2D pos, Vector2D size) { }
    public virtual void ClearBuffer(Pixel p, bool bDepth) { }

    public RCode CreateDevice(List<object> parameters, bool isFullScreen, bool isVsyncEnabled)
    {
        throw new NotImplementedException();
    }

    public void DrawLayerQuad(Vector2D offset, Vector2D scale, Pixel tint)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}
