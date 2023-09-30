using CSharpPixelGameEngine;

namespace WinFormsPlatform;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var platform = new WinformsPlatform();
        Application.Run(platform.gameWindow);
    }
}