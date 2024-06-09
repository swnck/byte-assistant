using byte_assistant_app.extra;
using byte_assistant_app.openai;
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
    static async Task Main()
    {
        _richPresenceManager.Initialize();
        _translationManager.Initialize();
        
        Recognition recognition = new Recognition();
        await recognition.InitializeAsync();
        
        ApplicationConfiguration.Initialize();
        Application.Run(new GenericTrayIcon());
    }
}