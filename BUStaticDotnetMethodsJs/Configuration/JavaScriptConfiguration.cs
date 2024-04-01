namespace BUStaticDotnetMethodsJs.Configuration;

public static class JavaScriptConfiguration
{
    private static JavaScriptSettings Settings;

    internal static void SetSettings(JavaScriptSettings settings)
    {
        Settings = settings;
    }

    public static JavaScriptSettings GetSettings() => Settings;
}
