using System.Globalization;

namespace byte_assistant_app.manager;

public abstract class Manager: IDisposable
{
    public abstract void Initialize();
    public abstract void Initialize(CultureInfo ci);

    public void Dispose() {}
}