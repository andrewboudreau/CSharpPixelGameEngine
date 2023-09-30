namespace CSharpPixelGameEngine;

public interface IPlatform
{
    RCode ApplicationStartUp();
    RCode ApplicationCleanUp();
    RCode ThreadStartUp();
    RCode ThreadCleanUp();
    RCode CreateGraphics(bool fullScreen, bool enableVsync, Vector2D viewPos, Vector2D viewSize);
    RCode CreateWindowPane(Vector2D windowPos, ref Vector2D windowSize, bool fullScreen);
    RCode SetWindowTitle(string title);
    RCode StartSystemEventLoop();
    RCode HandleSystemEvent();
}
