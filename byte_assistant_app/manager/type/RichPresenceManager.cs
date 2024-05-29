using System.Globalization;
using byte_assistant_app.manager;
using DiscordRPC;
using DiscordRPC.Logging;
using Button = DiscordRPC.Button;
using Timer = System.Threading.Timer;

namespace byte_assistant_app.extra;

public class RichPresenceManager : Manager
{
    private DiscordRpcClient _client = new DiscordRpcClient("1244730656441761802");
    
    private string _state = "Listen to: Byte, ...  ";
    
    public override void Initialize()
    {
        _client.OnReady += (s, e) => Console.WriteLine($"Received Ready from user {e.User.Username}");
        _client.Logger = new ConsoleLogger()
        {
            Level = LogLevel.Warning
        };
        _client.Initialize();
        _client.SetPresence(new RichPresence()
            {
                State = _state,
                Timestamps = Timestamps.Now,
                
                Buttons = new Button[]
                {
                    new Button() { Label = "GitHub", Url = "https://github.com/swnck/byte-assistant" },
                    new Button() { Label = "Discord", Url = "https://discord.gg/docker" }
                },
                
                Assets = new Assets()
                {
                    LargeImageKey = "byte_logo",
                    LargeImageText = "https://github.com/swnck/byte-assistant",
                    SmallImageKey = "github",
                    SmallImageText = "https://github.com/swnck/byte-assistant"
                }
            }
        );
    }

    public override void Initialize(CultureInfo ci)
    {
        throw new NotImplementedException();
    }

    public void update(string state)
    {
        _state = state;
        UpdatePresence();
    }
    
    private void UpdatePresence()
    {
        _client.Invoke();
    }
    
    public void Dispose()
    {
        _client.Dispose();
    }
}