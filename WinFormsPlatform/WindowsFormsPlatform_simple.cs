namespace CSharpPixelGameEngine;


public class WindowsFormsPlatform_simple : IPlatform
{
    internal readonly Form gameForm;

    public WindowsFormsPlatform_simple(Form form)
    {
        gameForm = form ?? throw new ArgumentNullException(nameof(form));
    }

    public RCode ApplicationStartUp()
    {
        // Initialization logic
        return RCode.OK;
    }

    public RCode ApplicationCleanUp()
    {
        // Cleanup logic
        return RCode.OK;
    }

    public RCode ThreadStartUp()
    {
        // Thread startup logic
        return RCode.OK;
    }

    public RCode ThreadCleanUp()
    {
        // Thread cleanup logic
        return RCode.OK;
    }

    public RCode CreateGraphics(bool fullScreen, bool enableVsync, Vector2D viewPos, Vector2D viewSize)
    {
        // Graphics setup logic
        return RCode.OK;
    }

    public RCode CreateWindowPane(Vector2D windowPos, ref Vector2D windowSize, bool fullScreen)
    {
        gameForm.Location = new Point((int)windowPos.x, (int)windowPos.y);
        gameForm.ClientSize = new Size((int)windowSize.x, (int)windowSize.y);
        gameForm.FormBorderStyle = fullScreen ? FormBorderStyle.None : FormBorderStyle.Sizable;
        return RCode.OK;
    }

    public RCode SetWindowTitle(string title)
    {
        gameForm.Text = title;
        return RCode.OK;
    }

    public RCode StartSystemEventLoop()
    {
        // Start WinForms event loop (Application.Run is generally called elsewhere)
        return RCode.OK;
    }

    public RCode HandleSystemEvent()
    {
        // Event handling logic
        return RCode.OK;
    }
}

