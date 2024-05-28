using Microsoft.Win32;

namespace byte_assistant_app.util;

public class SystemFunctions
{
    public static void setAutoStart() {
        const string runKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        const string appName = "Byte-Assistant";
        string appPath = Application.ExecutablePath;

        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(runKey, true))
        {
            if (key != null)
            {
                key.SetValue(appName, appPath);
            }
            else
            {
                using (RegistryKey newKey = Registry.CurrentUser.CreateSubKey(runKey))
                {
                    newKey.SetValue(appName, appPath);
                }
            }
        }
    }
}