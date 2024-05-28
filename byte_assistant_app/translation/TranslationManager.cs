using System.Collections;
using System.Globalization;

namespace byte_assistant_app.translation;

public class TranslationManager
{
    public static ArrayList translations = new ArrayList();
    
    private static CultureInfo _ci;
    
    public void Initialize(CultureInfo ci)
    {
        _ci = ci;
        
        translations.Add(new Translation("en-US")
            .addTranslation("app_name", "Byte Assistant")
        );
        
        //ToDo: Add locale configs or more translations
    }

    public static ArrayList getTranslations()
    {
        return translations;
    }
    
    public static Translation getTranslation(String locale)
    {
        foreach (Translation translation in translations)
        {
            if (translation.getLocale().Equals(locale))
            {
                return translation;
            }
        }

        return null;
    }
    
    public static String translate(String key, Dictionary<String, object> parameters = null)
    {
        Translation translation = getTranslation(_ci.Name);
        if (translation != null) {
            String translated = translation.getTranslation(key);
            if (parameters != null) {
                foreach (KeyValuePair<String, object> entry in parameters)
                {
                    translated = translated.Replace("{" + entry.Key + "}", entry.Value.ToString());
                }
            }
            return translated;
        }
        return "%"+key+"%";
    }
}