namespace CSharpPixelGameEngine;

using System.Windows.Forms;

public class WinformsPlatform : Platform_Headless
{
    internal Form gameWindow;

    public override RCode ApplicationStartUp()
    {
        // Initialization code can go here
        return RCode.OK;
    }

    public override RCode ApplicationCleanUp()
    {
        // Cleanup code can go here
        return RCode.OK;
    }

    public override RCode ThreadStartUp()
    {
        // Thread initialization can go here
        return RCode.OK;
    }

    public override RCode ThreadCleanUp()
    {
        // Thread cleanup can go here
        return RCode.OK;
    }

    public override RCode CreateGraphics(bool bFullScreen, bool bEnableVSYNC, Vector2D vViewPos, Vector2D vViewSize)
    {
        // Create and configure graphics device
        // This would be handled differently in WinForms
        return RCode.OK;
    }

    public override RCode CreateWindowPane(Vector2D vWindowPos, ref Vector2D vWindowSize, bool bFullScreen)
    {
        gameWindow = new Form
        {
            Text = "OLC_PIXEL_GAME_ENGINE",
            StartPosition = FormStartPosition.Manual,
            Location = vWindowPos,
            ClientSize = vWindowSize
        };

        // Full-screen support
        if (bFullScreen)
        {
            gameWindow.FormBorderStyle = FormBorderStyle.None;
            gameWindow.WindowState = FormWindowState.Maximized;
        }

        // Register event handlers

        // Mouse Move Event
        gameWindow.MouseMove += (sender, e) => UpdateMouse(e.Location.X, e.Location.Y);

        // Key Press Events
        gameWindow.KeyDown += (sender, e) => UpdateKeyState(e.KeyCode, true);
        gameWindow.KeyUp += (sender, e) => UpdateKeyState(e.KeyCode, false);

        // Window Close Event
        gameWindow.FormClosing += (sender, e) => Terminate();

        // Mouse Button Events
        gameWindow.MouseDown += (sender, e) => UpdateMouseState(e.Button, true);
        gameWindow.MouseUp += (sender, e) => UpdateMouseState(e.Button, false);

        // Finally, show the window
        gameWindow.Show();

        return RCode.OK;
    }

    public override RCode SetWindowTitle(string title)
    {
        gameWindow.Text = title;
        return RCode.OK;
    }

    public override RCode StartSystemEventLoop()
    {
        Application.Run(gameWindow);
        return RCode.OK;
    }

    public override RCode HandleSystemEvent()
    {
        // Custom system events handling can go here
        return RCode.FAIL;
    }

    private void UpdateMouse(int x, int y)
    {
        Console.WriteLine($"Mouse pressed at {x}, {y}");
    }

    private void UpdateKeyState(Keys key, bool isPressed)
    {
        Console.WriteLine($"Key pressed key {key} is pressed {isPressed}.");
    }

    private void Terminate()
    {
        Console.Write("Terminate");
    }

    private void UpdateMouseState(MouseButtons button, bool isPressed)
    {
        Console.WriteLine($"Mouse button {button} is pressed {isPressed}");
    }
}
