using byte_assistant_app.extra;

namespace byte_assistant_app;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        new RichPresenceManager().Initialize();
        ApplicationConfiguration.Initialize();
        Application.Run(new GenericTrayIcon());
    }
}