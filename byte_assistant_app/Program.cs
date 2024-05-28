using System.Globalization;
using byte_assistant_app.extra;
using byte_assistant_app.translation;

namespace byte_assistant_app;

static class Program
{
    private static TranslationManager _translationManager = new TranslationManager();
    private static RichPresenceManager _richPresenceManager = new RichPresenceManager();
    
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        _richPresenceManager.Initialize();
        _translationManager.Initialize(CultureInfo.InstalledUICulture);
        
        ApplicationConfiguration.Initialize();
        Application.Run(new GenericTrayIcon());
    }
}