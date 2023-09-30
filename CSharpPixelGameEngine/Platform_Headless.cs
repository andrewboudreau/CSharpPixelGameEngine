namespace CSharpPixelGameEngine;

// Headless Platform
public class Platform_Headless : IPlatform
{
    public virtual RCode ApplicationStartUp() => RCode.OK;
    public virtual RCode ApplicationCleanUp() => RCode.OK;
    public virtual RCode ThreadStartUp() => RCode.OK;
    public virtual RCode ThreadCleanUp() => RCode.OK;
    public virtual RCode CreateGraphics(bool bFullScreen, bool bEnableVSYNC, Vector2D vViewPos, Vector2D vViewSize) => RCode.OK;
    public virtual RCode CreateWindowPane(Vector2D vWindowPos, ref Vector2D vWindowSize, bool bFullScreen) => RCode.OK;
    public virtual RCode SetWindowTitle(string title) => RCode.OK;
    public virtual RCode StartSystemEventLoop() => RCode.OK;
    public virtual RCode HandleSystemEvent() => RCode.OK;
}