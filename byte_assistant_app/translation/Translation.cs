using System.Collections;

namespace byte_assistant_app.translation;

public class Translation
{
    public String locale { get; set; }
    public Dictionary<String, String> translations = new Dictionary<string, string>();
    
    public Translation(String locale)
    {
        this.locale = locale;
    }
    
    public Translation addTranslation(String key, String value)
    {
        translations.Add(key, value);
        return this;
    }
    
    public String getTranslation(String key)
    {
        return translations[key];
    }
    
    public String getLocale()
    {
        return locale;
    }
    
    public Dictionary<String, String> getTranslations()
    {
        return translations;
    }
    
    public void setLocale(String locale)
    {
        this.locale = locale;
    }
    
    public void setTranslations(Dictionary<String, String> translations)
    {
        this.translations = translations;
    }
}